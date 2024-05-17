using MongoDB.Driver;
using POC_Mongo.Src.Domain.Entities;
using POC_Mongo.Src.Repositories.MongoDB;

namespace POCMONGO.Domain.Entities
{
    public class Visit : Entity, IEntity
    {
        private const string COLLECTION_NAME = "Visit";

        private IMongoCollection<Visit> collection;

        public String local {  get; set; }
        public String period {  get; set; }
        public String responsable {  get; set; }
        public Visitor[] visitors {  get; set; }
        public Item[] items { get; set; }


        public Visit()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Visit>(COLLECTION_NAME);
        }

        public async Task<List<Visit>> getAll()
        {
            List<Visit> items = await collection.Find(_ => true).ToListAsync();
            return items;
        }

        public async Task<Visit> getOne(string id)
        {
            return await collection.Find((x) => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Boolean> save()
        {
            try
            {
                foreach (var visitor in this.visitors)
                {
                    visitor.save();
                }
                await collection.InsertOneAsync(this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> update()
        {
            try
            {
                await collection.ReplaceOneAsync<Visit>((x) => x.Id == Id, this);
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
                await collection.DeleteOneAsync<Visit>((x) => x.Id == Id);
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
