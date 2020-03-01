using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _product = database.GetCollection<Product>(settings.BooksCollectionName);
        }

        public List<Product> Get() =>
            _product.Find(product => true).ToList();

        public Product Get(string id) =>
            _product.Find<Product>(product => product.productId == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _product.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn) =>
            _product.ReplaceOne(product => product.productId == id, productIn);

        public void Remove(Product productIn) =>
            _product.DeleteOne(product => product.productId == productIn.productId);

        public void Remove(string id) =>
            _product.DeleteOne(product => product.productId == id);
    }
}