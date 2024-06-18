using MongoDB.Driver;
using POC_Mongo.Src.Domain.Entities;
using POC_Mongo.Src.Repositories.MongoDB;
using POCMONGO.Controllers.Filter;
using System.Text.RegularExpressions;

namespace POCMONGO.Domain.Entities
{
    public class Acervo : Entity, IEntity
    {
        private const string COLLECTION_NAME = "Acervo";

        private IMongoCollection<Acervo> collection;

        public string id { get; set; }
        public string code{ get; set; }
        public int classification { get; set; }
        public int year { get; set; }
        public int quantity { get; set; }
        public int height { get; set; }
        public int width{ get; set; }
        public string information { get; set; }
        public string[] picture { get; set; }
        public string[] links{ get; set; }
        public string storagePlace { get; set; }
        public string donerName { get; set; }
        public string donationDate { get; set; }
        public string manufacturer { get; set; }
        public string category { get; set; }



        public Acervo()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Acervo>(COLLECTION_NAME);
        }

        public async Task<List<Acervo>> getAll(AcervoFilter filter)
        {
            List<Acervo> items;
            string seachValue = "";

            if (filter.code != "")
                seachValue += "(" + filter.code + ")";
            if (filter.classification != "")
                seachValue += "(" + filter.classification + ")";
            if (filter.year != "")
                seachValue += "(" + filter.year + ")";
            if (filter.category != "")
                seachValue += "(" + filter.category + ")";
            if (filter.manufacturer != "")
                seachValue += "(" + filter.manufacturer + ")";
            if (filter.storagePlace != "")
                seachValue += "(" + filter.storagePlace + ")";
            
            Regex regex = new Regex(seachValue, RegexOptions.IgnoreCase);

            if (filter.HasFilter())
            {
                items = collection.AsQueryable().Where(acervo =>
                    regex.IsMatch(acervo.code) ||
                    regex.IsMatch(Convert.ToString(acervo.classification)) ||
                    regex.IsMatch(Convert.ToString(acervo.year)) ||
                    regex.IsMatch(acervo.category) ||
                    regex.IsMatch(acervo.manufacturer) ||
                    regex.IsMatch(acervo.storagePlace)
                ).ToList();
            }
            else
            {
                items = await collection.Find(_ => true).ToListAsync();
            }

            return items;
        }

        public async Task<Acervo> getOne(string id)
        {
            return await collection.Find((x) => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<Boolean> update()
        {
            try 
            { 
                await collection .ReplaceOneAsync(x => x.id == this.id, this);
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
                await collection.DeleteOneAsync(x => x.id == this.id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> save()
        {
            throw new NotImplementedException();
        }

        public Task<List<IEntity>> getAll()
        {
            throw new NotImplementedException();
        }

        Task<IEntity> IEntity.getOne(string id)
        {
            throw new NotImplementedException();
        }
    }
}
