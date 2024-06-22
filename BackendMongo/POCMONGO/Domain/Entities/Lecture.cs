using Amazon.Runtime.Internal.Transform;
using MongoDB.Bson;
using MongoDB.Driver;
using POC_Mongo.Src.Domain.Entities;
using POC_Mongo.Src.Repositories.MongoDB;
using POCMONGO.Controllers.Filter;
using POCMONGO.Domain.Validators;
using System.Text.RegularExpressions;

namespace POCMONGO.Domain.Entities
{
    public class Lecture : Entity, IEntity
    {
         private const string COLLECTION_NAME = "Lecture";


        private IMongoCollection<Lecture> collection;

        public string person { get; set; }
        public string local { get; set; }
        public string datetime { get; set; }
        public string duration { get; set; }
        public string resume { get; set; }
        public string brief { get; set; }
        public LectureValidator validator;

        public Lecture()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Lecture>(COLLECTION_NAME);
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

        public async Task<List<Lecture>> getAll(LectureFilter filter)
        {
            List<Lecture> items;
            string seachValue = "";

            if (filter.person != "")
                seachValue += "(" + filter.person + ")";
            if (filter.local != "")
                seachValue += "(" + filter.local + ")";
            if (filter.datetime != "")
                seachValue += "(" + filter.datetime + ")";

            Regex regex = new Regex(seachValue, RegexOptions.IgnoreCase);

            if (filter.HasFilter())
            {
                items = collection.AsQueryable().Where(lecture =>
                    regex.IsMatch(lecture.person ?? string.Empty) ||
                    regex.IsMatch(lecture.local ?? string.Empty) ||
                    regex.IsMatch(lecture.datetime ?? string.Empty)
                ).ToList();
            }
            else
            {
                items = await collection.Find(_ => true).ToListAsync();
            }

            return items;
        }

        public async Task<Lecture> getOne(string id)
        {
            return await collection.Find(Builders<Lecture>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefaultAsync();
        }

        public async Task<Boolean> update()
        {
            try
            {
                await collection.ReplaceOneAsync(Builders<Lecture>.Filter.Eq("_id", ObjectId.Parse(Id)), this);
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
                await collection.DeleteOneAsync(Builders<Lecture>.Filter.Eq("_id", ObjectId.Parse(Id)));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
