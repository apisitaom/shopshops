using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_shop.Models
{
    public class Recrive
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string recriveId;
        public bool recrivestatus;
    }
}
