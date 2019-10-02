namespace BeerApi.Interfaces
{
    public interface IBrewerySettings
    {
        string BreweryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}