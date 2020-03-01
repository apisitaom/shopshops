using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<Payment> _payment;

        public PaymentService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _payment = database.GetCollection<Payment>(settings.BooksCollectionName);
        }

        public List<Payment> Get() =>
            _payment.Find(payment => true).ToList();

        public Payment Get(string id) =>
            _payment.Find<Payment>(payment => payment.paymentId == id).FirstOrDefault();

        public Payment Create(Payment payment)
        {
            _payment.InsertOne(payment);
            return payment;
        }

        public void Update(string id, Payment paymentIn) =>
            _payment.ReplaceOne(payment => payment.paymentId == id, paymentIn);

        public void Remove(Payment paymentIn) =>
            _payment.DeleteOne(payment => payment.paymentId == paymentIn.paymentId);

        public void Remove(string id) =>
            _payment.DeleteOne(payment => payment.paymentId == id);
    }
}