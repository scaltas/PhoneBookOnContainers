using Report.API.Domain;

namespace Report.API.Application
{
    public interface IReportService
    {
        Task<List<ReportEntry>> GetAsync();
        Task<ReportEntry?> GetAsync(string id);
        Task<ReportEntry> CreateAsync();
    }
}
