using Example.DomainLayer;

namespace Example.Database.Repositories;

public interface IDistrictRepository
{
    Task<District> GetDistrictByCityAndName(string cityName, string districtName);
    Task AddAsync(District district);
    IQueryable<District> GetDistrictQueryble();
}
