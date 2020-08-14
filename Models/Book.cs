using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public decimal BookPrice { get; set; }
    }
}