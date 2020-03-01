using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class SellerService
    {
        private readonly IMongoCollection<Seller> _seller;

        public SellerService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _seller = database.GetCollection<Seller>(settings.BooksCollectionName);
        }

        public List<Seller> Get() =>
            _seller.Find(seller => true).ToList();

        public Seller Get(string id) =>
            _seller.Find<Seller>(seller => seller.sellerId == id).FirstOrDefault();

        public Seller Create(Seller seller)
        {
            _seller.InsertOne(seller);
            return seller;
        }

        public void Update(string id, Seller sellerIn) =>
            _seller.ReplaceOne(seller => seller.sellerId == id, sellerIn);

        public void Remove(Seller sellerIn) =>
            _seller.DeleteOne(seller => seller.sellerId == sellerIn.sellerId);

        public void Remove(string id) =>
            _seller.DeleteOne(seller => seller.sellerId == id);
    }
}