using MongoDB.Driver;
using POC_Mongo.Src.Repositories.MongoDB;
using POCMONGO.Domain.Entities;

namespace POC_Mongo.Src.Domain.Entities
{
    public class Donation: Entity
    {
        private const string COLLECTION_NAME = "Donation";
        private IMongoCollection<Donation> collection; 

        public string DonerName { get; set; }
        public string DonationDate {  get; set; }
        public decimal Ammount { get; set; }

        public Donation()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Donation>(COLLECTION_NAME);
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

        public async Task<Donation> getOne(string id)
        {
            return await collection.Find((x) => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
