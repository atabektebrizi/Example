using Example.DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace Example.Database;
public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder) {
        builder.Entity<City>().HasData(new City
        {
            Id = 1,
            Name = "Istanbul"
        });
    }
}
