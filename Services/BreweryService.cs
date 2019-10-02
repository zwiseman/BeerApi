using System.Collections.Generic;
using BeerApi.Interfaces;
using BeerApi.Models;
using MongoDB.Driver;

namespace BeerApi.Services
{
    public class BreweryService
    {
        private readonly IMongoCollection<Brewery> _brewery;

        public BreweryService(IBrewerySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _brewery = database.GetCollection<Brewery>(settings.DatabaseName);
        }

        public List<Brewery> Get() =>
            _brewery.Find(b => true).ToList();

        public Brewery Get(string id) =>
            _brewery.Find<Brewery>(b => b.Id == id).FirstOrDefault();

        public Brewery Create(Brewery brewery)
        {
            _brewery.InsertOne(brewery);
            return brewery;
        }

        public void Update(string id, Brewery brewery) =>
            _brewery.ReplaceOne(b => b.Id == id, brewery);

        public void Remove(Brewery brewery) =>
            _brewery.DeleteOne(b => b.Id == brewery.Id);

        public void Remove(string id) => 
            _brewery.DeleteOne(b => b.Id == id);
    }
}