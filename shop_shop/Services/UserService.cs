using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.BooksCollectionName);
        }

        public List<User> Get() =>
            _user.Find(user => true).ToList();

        public User Get(string id) =>
            _user.Find<User>(user => user.userId == id).FirstOrDefault();

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _user.ReplaceOne(user => user.userId == id, userIn);

        public void Remove(User userIn) =>
            _user.DeleteOne(user => user.userId == userIn.userId);

        public void Remove(string id) =>
            _user.DeleteOne(user => user.userId == id);
    }
}