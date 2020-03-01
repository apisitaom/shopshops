using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shop_shop.Models
{
    public class Option
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string optionId;
        public string[] option;
        public string[] price;
    }
}
