using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerApi.Models 
{
    public class Brewery 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string BeerName { get; set; }
        public string BreweryName { get; set; }
        public double Rating { get; set; }
        public string Comments { get; set; }
    }
}