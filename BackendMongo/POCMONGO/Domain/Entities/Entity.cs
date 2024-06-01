using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using POCMONGO.Domain.Entities;

namespace POC_Mongo.Src.Domain.Entities
{
    public abstract class Entity
    {

        protected static String DATABASE = "bitbus";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
