using Example.Database.UnitofWork;
using Example.DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace Example.ApplicationLayer;

public class DistrictService : IDistrictService
{

    private readonly IUnitOfWork _unitOfWork;

    public DistrictService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //private readonly List<District> Districts = new List<District>()
    //{
    //    new District{CityCode="IST",Name="Ataşehir"},
    //    new District{CityCode="IST",Name="Kadılöy"},
    //    new District{CityCode="IZM",Name="Karşıyaka"}
    //};

    //public List<District> GetDistricts(string cityCode)
    //{
    //    var result = Districts.Where(s => s.CityCode == cityCode).ToList();
    //    return result;
    //}



    public async Task<dynamic> GetAllDistrictsWithPersonnel()
    {
        var personnelQuery = _unitOfWork.Personnels.GetPersonnelQueryble();
        var districtQuery = _unitOfWork.Districts.GetDistrictQueryble();


        //var leftJoin = await districtQuery.GroupJoin(personnelQuery, d => d.Id, p => p.DistrictId,
        //    (d, p) => new { District = d, Personnel = p })
        //    .SelectMany(d => d.Personnel.DefaultIfEmpty(),
        //    (d, p) => new
        //    {
        //        DistrictName = d.District.Name,
        //        Personels = p != null ? p.FullName : string.Empty
        //    }).ToListAsync();


        var leftJoinWithRelation =await districtQuery.Select(s => new
        {
            s.Name,
            Personnel=s.Personnels.Select(c => c.FullName).ToList()
        }).ToListAsync();


        return leftJoinWithRelation;
    }


    public async Task<dynamic> GetDistrictGroups()
    {
        var query =await _unitOfWork.Districts.GetDistrictQueryble()
            .GroupBy(s => s.Name)
            .Select(s => new
            {
                DistrictName = s.Key,
                Personnels = s.Select(c => c.Personnels.Select(p => p.FullName)).ToList()
            }).ToListAsync();

        return query;
    }
}
