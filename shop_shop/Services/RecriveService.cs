using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class RecriveService
    {
        private readonly IMongoCollection<Recrive> _recrive;

        public RecriveService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _recrive = database.GetCollection<Recrive>(settings.BooksCollectionName);
        }

        public List<Recrive> Get() =>
            _recrive.Find(recrive => true).ToList();

        public Recrive Get(string id) =>
            _recrive.Find<Recrive>(recrive => recrive.recriveId == id).FirstOrDefault();

        public Recrive Create(Recrive recrive)
        {
            _recrive.InsertOne(recrive);
            return recrive;
        }

        public void Update(string id, Recrive recriveIn) =>
            _recrive.ReplaceOne(recrive => recrive.recriveId == id, recriveIn);

        public void Remove(Recrive recriveIn) =>
            _recrive.DeleteOne(recrive => recrive.recriveId == recriveIn.recriveId);

        public void Remove(string id) =>
            _recrive.DeleteOne(recrive => recrive.recriveId == id);
    }
}