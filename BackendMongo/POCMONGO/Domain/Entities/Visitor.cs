using MongoDB.Driver;
using POC_Mongo.Src.Domain.Entities;
using POC_Mongo.Src.Repositories.MongoDB;

namespace POCMONGO.Domain.Entities
{
    public class Visitor : Entity
    {
        private const string COLLECTION_NAME = "Visitor";
        private IMongoCollection<Visitor> collection;
        public string? Name { get; set; }

        public Visitor()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Visitor>(COLLECTION_NAME);
        }

        public async Task<Boolean> save()
        {
            try
            {
                await collection.InsertOneAsync(this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
