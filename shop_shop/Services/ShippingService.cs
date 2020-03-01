using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class ShippingService
    {
        private readonly IMongoCollection<Shipping> _shipping;

        public ShippingService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shipping = database.GetCollection<Shipping>(settings.BooksCollectionName);
        }

        public List<Shipping> Get() =>
            _shipping.Find(shipping => true).ToList();

        public Shipping Get(string id) =>
            _shipping.Find<Shipping>(shipping => shipping.shippingId == id).FirstOrDefault();

        public Shipping Create(Shipping shipping)
        {
            _shipping.InsertOne(shipping);
            return shipping;
        }

        public void Update(string id, Shipping shippingIn) =>
            _shipping.ReplaceOne(shipping => shipping.shippingId == id, shippingIn);

        public void Remove(Shipping shippingIn) =>
            _shipping.DeleteOne(shipping => shipping.shippingId == shippingIn.shippingId);

        public void Remove(string id) =>
            _shipping.DeleteOne(shipping => shipping.shippingId == id);
    }
}