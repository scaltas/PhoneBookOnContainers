using MongoDB.Bson.Serialization;

namespace Contact.API.Infrastructure.Mongo
{
    public class ContactMap
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Domain.ContactEntry>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Name).SetIsRequired(true);
            });
        }
    }
}
