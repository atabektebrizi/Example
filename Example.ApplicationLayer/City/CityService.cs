using Example.Database.Repositories;
using Example.Database.UnitofWork;
using Example.DomainLayer;

namespace Example.ApplicationLayer;

public class CityService:ICityService
{
    private readonly IUnitOfWork _unitOfWork;

    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task Add(City city)
    {
        await _unitOfWork.Cities.AddAsync(city);
        await _unitOfWork.CompleteAsync();
    }    


    //test


    //public readonly List<City> Cities = new List<City>()
    //{
    //    new City(){Name="İstanbul",Code="IST"},
    //    new City(){Name="İzmir",Code="IZM"}
    //};

    //public List<City> GetCityList()
    //{
    //    return Cities;
    //}
}
