using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_shop.Models
{
    public class Seller
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string sellerId;
        public string sellerName;
        public string email;
        public string password;
        public string phone;
    }
}
