using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shop_shop.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string bookId { get; set; }

        public string bookName { get; set; }

        public decimal price { get; set; }

        public string category { get; set; }

        public string author { get; set; }
    }
}