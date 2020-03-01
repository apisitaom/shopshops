using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_shop.Models
{
    public class Shipping
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string shippingId;
        public string taxid;
        public string shippingstatus;
    }
}
