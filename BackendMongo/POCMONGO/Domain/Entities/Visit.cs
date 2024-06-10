using MongoDB.Driver;
using POC_Mongo.Src.Domain.Entities;
using POC_Mongo.Src.Repositories.MongoDB;
using POCMONGO.Controllers.Filter;
using System.Text.RegularExpressions;

namespace POCMONGO.Domain.Entities
{
    public class Visit : Entity, IEntity
    {
        private const string COLLECTION_NAME = "Visit";

        private IMongoCollection<Visit> collection;

        public String place {  get; set; }
        public String period {  get; set; }
        public String responsable {  get; set; }
        public Visitor[] visitors {  get; set; } = new Visitor[0];
        public Item[] items { get; set; } = new Item[0];


        public Visit()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Visit>(COLLECTION_NAME);
        }

        public async Task<List<Visit>> getAll(VisitFilter filter)
        {
            List<Visit> items;
            var searchValue = "";
            if (filter.place != "")
            {
                searchValue += "(" + filter.place + ")";
            }
            if (filter.responsable != "")
            {
                searchValue += "(" + filter.responsable + ")";
;
            }
            if (filter.period != "")
            {
                searchValue += "(" + filter.period + ")";
            }

            var regex = new Regex(searchValue, RegexOptions.IgnoreCase);

            if (filter.HasFilter())
            {
                items = collection.AsQueryable().Where(visit =>
                    regex.IsMatch(visit.place) ||
                    regex.IsMatch(visit.responsable) ||
                    regex.IsMatch(visit.period)
                ).ToList();
            }
            else
            {
                items = await collection.Find(_ => true).ToListAsync();
            }
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
