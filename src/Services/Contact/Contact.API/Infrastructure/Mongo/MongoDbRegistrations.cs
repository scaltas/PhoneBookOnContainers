using Contact.API.Application;

namespace Contact.API.Infrastructure.Mongo
{
    public static class MongoDbRegistrations
    {
        public static IServiceCollection AddMongoDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(
                configuration.GetSection("ContactDatabase"));

            ContactMap.Map();

            services.AddSingleton<IContactService, ContactService>();

            return services;
        }
    }
}
