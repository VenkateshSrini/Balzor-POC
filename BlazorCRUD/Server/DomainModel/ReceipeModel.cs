using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.DomainModel
{
    public class ReceipeModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ReceipeID { get; set; }
       [BsonElement("ReceipeName")]
        public string ReceipeName { get; set; }
        [BsonElement("Ingredients")]
        public string Ingredients { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Notes")]
        public string Notes { get; set; }
    }
}
