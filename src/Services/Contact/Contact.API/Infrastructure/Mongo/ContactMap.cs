using Contact.API.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Contact.API.Infrastructure.Mongo
{
    public class ContactMap
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<ContactEntry>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id)
                    .SetIdGenerator(new StringObjectIdGenerator())
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                map.MapMember(x => x.Name).SetIsRequired(true);
            });
        }
    }
}
