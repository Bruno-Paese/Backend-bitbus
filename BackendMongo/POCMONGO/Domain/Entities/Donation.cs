using MongoDB.Driver;
using POC_Mongo.Src.Repositories.MongoDB;

namespace POC_Mongo.Src.Domain.Entities
{
    public class Donation: Entity
    {
        private const string COLLECTION_NAME = "Donation";

        public string DonerName { get; set; }
        public string DonationDate {  get; set; }
        public decimal Ammount { get; set; }

        public Donation()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Item>("jorge");
        }
    }
}
