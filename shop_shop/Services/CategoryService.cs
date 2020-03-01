using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _category;

        public CategoryService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _category = database.GetCollection<Category>(settings.BooksCollectionName);
        }

        public List<Category> All() =>
            _category.Find(category => true).ToList();

        public Category Get(string id) =>
            _category.Find<Category>(category => category.categoryId == id).FirstOrDefault();

        public Category Create(Category category)
        {
            _category.InsertOne(category);
            return category;
        }

        public void Update(string id, Category categoryIn) =>
            _category.ReplaceOne(category => category.categoryId == id, categoryIn);

        public void Remove(Category categoryIn) =>
            _category.DeleteOne(category => category.categoryId == categoryIn.categoryId);

        public void Remove(string id) =>
            _category.DeleteOne(category => category.categoryId == id);
    }
}