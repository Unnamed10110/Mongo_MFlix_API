using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_MFlix_API.Models
{
    [BsonIgnoreExtraElements]
    public class MFlix_Collection
    {
        [BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("plot")]
        public string Plot { get; set; }
        [BsonElement("genres")]
        public List<string> Genres { get; set; }
        [BsonElement("runtime")]
        public int Runtime { get; set; }
        [BsonElement("poster")]
        public string Poster { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("fullplot")]
        public string FullPlot { get; set; }

        [BsonElement("released")]
        public string Released { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }


    }
}
