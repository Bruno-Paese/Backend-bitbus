using MongoDB.Driver;
using POC_Mongo.Src.Repositories.MongoDB;
namespace POCMONGO.Domain.Entities
{
    public class Item : Entity, IEntity
    {
        private IMongoCollection<Item> collection;
        public string Code { get; set; }
        public int Classification { get; set; }
        public int Category { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public string Information { get; set; }
        public List<string> Pictures { get; set; }
        public List<string> Links { get; set; }
        public string StoragePlace { get; set; }
        public string DonorName { get; set; }
        public string DonationDate { get; set; }
        public string Manufacturer { get; set; }

        public Item()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Item>("Item");
        }

        public async Task<List<Item>> getAll()
        {
            List<Item> items = await collection.Find(_ => true).ToListAsync();
            return items;
        }

        public async Task<Item> getOne(string id)
        {
            return await collection.Find((x) => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Boolean> save()
        {
            try
            {
                await collection.InsertOneAsync(this);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> update()
        {
            try {
                await collection.ReplaceOneAsync<Item>((x) => x.Id == Id, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> delete()
        {
            try
            {
                await collection.DeleteOneAsync<Item>((x) => x.Id == Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        Task<List<IEntity>> IEntity.getAll()
        {
            throw new NotImplementedException();
        }

        Task<IEntity> IEntity.getOne(string id)
        {
            throw new NotImplementedException();
        }
    }
}