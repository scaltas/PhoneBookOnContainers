using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Report.API.Domain;

namespace Report.API.Infrastructure.Mongo
{
    public class ReportMap
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<ReportEntry>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id)
                    .SetIdGenerator(new StringObjectIdGenerator())
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                map.MapMember(x => x.RequestDate).SetIsRequired(true);
                map.MapMember(x => x.Status).SetIsRequired(true);
            });
        }
    }
}
