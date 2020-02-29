using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _address = database.GetCollection<Address>(settings.BooksCollectionName);
        }

        public List<Address> Alladdress() =>
            _address.Find(address => true).ToList();

        public Address Getaddress(string id) =>
            _address.Find<Address>(address => address.addressId == id).FirstOrDefault();

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address addressIn) =>
            _address.ReplaceOne(address => address.addressId == id, addressIn);

        public void Remove(Address addressIn) =>
            _address.DeleteOne(address => address.addressId == addressIn.addressId);

        public void Remove(string id) =>
            _address.DeleteOne(address => address.addressId == id);
    }
}