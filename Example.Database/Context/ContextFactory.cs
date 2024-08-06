using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Example.Database;

public sealed class ContextFactory:IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "Server=DESKTOP-0HQ9090;Database=ExampleDB;Integrated Security=true;TrustServerCertificate=true;";
        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
    }
}
