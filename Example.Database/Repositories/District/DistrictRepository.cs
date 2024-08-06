using Example.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Example.Database.Repositories;

public class DistrictRepository : IDistrictRepository
{
    private readonly Context _context;

    public DistrictRepository(Context context)
    {
        _context = context;
    }

    public async Task<District> GetDistrictByCityAndName(string cityName, string districtName)
    {
        var record=await _context.Set<District>().Where(s=>s.City.Name==cityName && s.Name==districtName).FirstOrDefaultAsync();
        return record;
    }

    public async Task AddAsync(District district)
    {
        await _context.Set<District>().AddAsync(district);
        await _context.SaveChangesAsync();
    }

    public IQueryable<District> GetDistrictQueryble()
    {
        return _context.Set<District>();        
    }
}
