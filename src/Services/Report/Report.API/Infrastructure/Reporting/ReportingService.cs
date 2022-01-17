using Newtonsoft.Json;
using Report.API.Application;
using Report.API.BackgroundServices.Models;
using Report.API.BackgroundServices.Util;
using Report.API.Domain;
using Report.API.Events;

namespace Report.API.BackgroundServices
{
    public class ReportingService : BackgroundService
    {
        private readonly IBus _eventBus;
        private readonly IReportService _reportService;

        public ReportingService(IBus eventBus, IReportService reportService)
        {
            _eventBus = eventBus;
            _reportService = reportService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventBus.ReceiveAsync<ReportRequestedEvent>("ReportQueue", e =>
            {
                Task.Run(async () => {
                    using var httpClient = new HttpClient();
                    using var response = await httpClient.GetAsync("http://contact.api/api/v1/Contacts", stoppingToken);
                    var apiResponse = await response.Content.ReadAsStringAsync(stoppingToken);
                    var contacts = JsonConvert.DeserializeObject<List<Contact>>(apiResponse);

                    var locationStats = new Dictionary<string, LocationInfo>();
                    foreach (var contact in contacts)
                    {
                        var location = contact.ContactInfos.FirstOrDefault(c => c.Type == ContactType.Location)?.Value;
                        if (location != null)
                        {
                            if (!locationStats.ContainsKey(location))
                                locationStats[location] = new LocationInfo();

                            locationStats[location].NumberOfPeople++;

                            var phones = contact.ContactInfos.Where(c => c.Type == ContactType.Phone);
                            foreach (var phone in phones)
                            {
                                locationStats[location].NumberOfPhoneNumbers++;
                            }
                        }
                    }

                    var locationReport = new List<LocationStats>();
                    foreach (var (key, value) in locationStats)
                    {
                        locationReport.Add(new LocationStats()
                        {
                            Location = key,
                            Info = value
                        });
                    }

                    var csvStr = new ReportGenerator().GenerateReport(locationReport);

                    var filePath = $"/reports/{e.Id}.csv";
                    var file = new FileInfo(filePath);
                    file.Directory!.Create();
                    await File.WriteAllTextAsync(file.FullName, csvStr, stoppingToken);

                    var report = new ReportEntry()
                    {
                        Id = e.Id,
                        RequestDate = e.RequestDate,
                        Status = ReportStatus.Completed,
                        LocationStats = locationReport
                    };
                    await _reportService.UpdateAsync(report);

                }, stoppingToken);
            });
        }
    }
}
