using MongoDB.Driver;
using POC_Mongo.Src.Domain.Entities;
using POC_Mongo.Src.Repositories.MongoDB;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Domain.Entities
{
    public class Visitor : Entity
    {
        private const string COLLECTION_NAME = "Visitor";
        private IMongoCollection<Visitor> collection;
        public string Name { get; set; }
        public string? email { get; set; }

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

        public async Task<Visitor> getByName()
        {
            try
            {
                var visitor = await collection.Find(x => x.Name == this.Name).FirstOrDefaultAsync();
                return visitor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Visitor getById()
        {
            try
            {
                var visitor = collection.Find(x => x.Id == this.Id).FirstOrDefault();
                return visitor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
