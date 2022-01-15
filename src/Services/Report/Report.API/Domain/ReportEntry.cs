namespace Report.API.Domain
{
    public class ReportEntry
    {
        public string? Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public string FilePath { get; set; } = null!;
    }
}
