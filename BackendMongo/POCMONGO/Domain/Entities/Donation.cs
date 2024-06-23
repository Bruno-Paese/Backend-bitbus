using MongoDB.Driver;
using NUnit.Framework.Interfaces;
using POC_Mongo.Src.Repositories.MongoDB;
using POCMONGO.Controllers.Filter;
using POCMONGO.Domain.Entities;
using System.Text.RegularExpressions;

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

        public async Task<Boolean> Save()
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

        public async Task<Donation> GetOne(string id)
        {
            return await collection.Find((x) => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Donation>> GetAll(DonationFilter donationFilter)
        {
            List<Donation> items;


            if (donationFilter.HasFilter())
            {
                Regex regex = donationFilter.GetFilterRegex();
                items = collection.AsQueryable().Where(Donation =>
                    regex.IsMatch(Donation.DonationDate) ||
                    regex.IsMatch(Donation.DonerName)
                ).ToList();
            }
            else
            {
                items = await collection.Find(_ => true).ToListAsync();
            }

            return items;
        }

        public async Task<Boolean> delete()
        {
            try
            {
                await collection.DeleteOneAsync(x => x.Id == this.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
