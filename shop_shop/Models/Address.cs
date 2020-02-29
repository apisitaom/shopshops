using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shop_shop.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string addressId { get; set; }
        public string subdistrict { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string postcode { get; set; }
        public string phone { get; set; }
    }
}
