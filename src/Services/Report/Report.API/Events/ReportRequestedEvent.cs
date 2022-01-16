namespace Report.API.Events;

public class ReportRequestedEvent
{
    public ReportRequestedEvent(string? id, DateTime requestDate)
    {
        Id = id;
        RequestDate = requestDate;
    }

    public string? Id { get; }
    public DateTime RequestDate { get; }
}