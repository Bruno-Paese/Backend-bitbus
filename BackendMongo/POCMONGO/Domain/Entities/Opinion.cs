using MongoDB.Driver;
using POC_Mongo.Src.Repositories.MongoDB;

namespace POCMONGO.Domain.Entities
{
    public class Opinion : Entity
    {
        private const string COLLECTION_NAME = "Opinion";

        private IMongoCollection<Opinion> collection;
        public Visit visit {  get; set; } = new Visit();
        public Visitor visitor { get; set; }
        public float score { get; set; }
        public string comment { get; set; }
        public string socialMedia { get; set; } = "";

        public Opinion()
        {
            MongoClient client = MongoDBRepository.connect();
            collection = client.GetDatabase(DATABASE).GetCollection<Opinion>(COLLECTION_NAME);
        }

        public async Task<List<Opinion>> getAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<Opinion> getCompiledOpinions(Visit visit)
        {
            List<Opinion> opinions = await collection.Find(x => x.visit.Id == visit.Id).ToListAsync();

            float compiledScore = 0;

            foreach (var op in opinions)
            {
                compiledScore += op.score;
            }

            Opinion opinion = new Opinion();
            opinion.score = compiledScore / opinions.Count();
            opinion.comment = "Os valores foram compilados de todas as notas da visita";

            return opinion;
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
