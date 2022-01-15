namespace Report.API.Infrastructure.Mongo
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ReportsCollectionName { get; set; } = null!;
    }
}
