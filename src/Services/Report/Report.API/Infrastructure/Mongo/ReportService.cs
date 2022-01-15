using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Report.API.Application;
using Report.API.Domain;
using Report.API.Infrastructure.Mongo;

namespace Report.API.Infrastructure
{
    public class ReportService : IReportService
    {
        private readonly IMongoCollection<ReportEntry> _reportsCollection;

        public ReportService(
            IOptions<DatabaseSettings> reportDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                reportDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                reportDatabaseSettings.Value.DatabaseName);

            _reportsCollection = mongoDatabase.GetCollection<ReportEntry>(
                reportDatabaseSettings.Value.ReportsCollectionName);
        }

        public async Task<List<ReportEntry>> GetAsync() =>
            await _reportsCollection.Find(_ => true).ToListAsync();

        public async Task<ReportEntry?> GetAsync(string id) =>
            await _reportsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<string> CreateAsync()
        {
            var reportToInsert = new ReportEntry()
            {
                RequestDate = DateTime.Now,
                Status = ReportStatus.BeingPrepared
            };
            await _reportsCollection.InsertOneAsync(reportToInsert);
            return reportToInsert.Id ?? string.Empty;
        }
    }
}
