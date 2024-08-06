using Microsoft.EntityFrameworkCore;

namespace Example.Database;

public sealed class Context:DbContext
{
    public Context(DbContextOptions options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly).Seed();
    
}
