using Report.API.Application;

namespace Report.API.Infrastructure.Mongo
{
    public static class MongoDbRegistrations
    {
        public static IServiceCollection AddMongoDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(
                configuration.GetSection("ReportDatabase"));

            ReportMap.Map();

            services.AddSingleton<IReportService, ReportService>();

            return services;
        }
    }
}
