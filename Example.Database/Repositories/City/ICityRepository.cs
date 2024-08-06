using Example.DomainLayer;

namespace Example.Database.Repositories;

public interface ICityRepository
{
    Task AddAsync(City city);
    Task<City> GetCityByName(string cityName);
}
