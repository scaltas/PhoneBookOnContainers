using Report.API.BackgroundServices.Models;

namespace Report.API.Domain
{
    public class ReportEntry
    {
        public string? Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public List<LocationStats> LocationStats { get; set; } = null!;
    }
}
