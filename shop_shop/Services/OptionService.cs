using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class OptionService
    {
        private readonly IMongoCollection<Option> _option;

        public OptionService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _option = database.GetCollection<Option>(settings.BooksCollectionName);
        }

        public List<Option> Get() =>
            _option.Find(option => true).ToList();

        public Option Get(string id) =>
            _option.Find<Option>(option => option.optionId == id).FirstOrDefault();

        public Option Create(Option option)
        {
            _option.InsertOne(option);
            return option;
        }

        public void Update(string id, Option optionIn) =>
            _option.ReplaceOne(option => option.optionId == id, optionIn);

        public void Remove(Option optionIn) =>
            _option.DeleteOne(option => option.optionId == optionIn.optionId);

        public void Remove(string id) =>
            _option.DeleteOne(option => option.optionId == id);
    }
}