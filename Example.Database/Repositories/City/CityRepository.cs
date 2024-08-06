using Example.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Database.Repositories;

public class CityRepository : ICityRepository
{
    private readonly Context _context;

    public CityRepository(Context context)
    {
        _context = context;
    }

    public async Task AddAsync(City city)
    {
        await _context.Set<City>().AddAsync(city);
        await _context.SaveChangesAsync();
    }

    public async Task<City> GetCityByName(string cityName)
    {
        var record = await _context.Set<City>().Where(s => s.Name == cityName).FirstOrDefaultAsync();
        return record;
    }
}
