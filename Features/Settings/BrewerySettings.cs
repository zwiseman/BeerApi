using BeerApi.Interfaces;

namespace BeerApi.Features
{
    public class BrewerySettings: IBrewerySettings
    {
        public string BreweryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}