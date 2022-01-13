namespace Report.API.Model
{
    public class Report
    {
        public Guid UUId { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public string FilePath { get; set; }
    }
}
