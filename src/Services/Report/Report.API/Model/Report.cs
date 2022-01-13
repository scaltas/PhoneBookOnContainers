namespace Report.API.Model
{
    public class Report
    {
        public string UuId { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public string FilePath { get; set; }
        public Report(string filePath, DateTime requestDate, ReportStatus status)
        {
            UuId = Guid.NewGuid().ToString();
            FilePath = filePath;
            RequestDate = requestDate;
            Status = status;
        }


    }
}
