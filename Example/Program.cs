using Example.ApplicationLayer;
using Example.ApplicationLayer.Personnels;
using Example.Database;
using Example.Database.Repositories;
using Example.Database.Repositories.Personnels;
using Example.Database.UnitofWork;
using Example.Middleware;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger=new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("Logs/log.txt",
	rollingInterval:RollingInterval.Day)
	.CreateLogger();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=DESKTOP-0HQ9090;Database=ExampleDB;Integrated Security=true;TrustServerCertificate=true;";
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IDistrictService, DistrictService>();
builder.Services.AddTransient<IPersonnelRepository, PersonnelRepository>();
builder.Services.AddTransient<IPersonnelService, PersonnelService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext=scope.ServiceProvider.GetRequiredService<Context>();

	try
	{
		dbContext.Database.CanConnect();
		Console.Write("DB Connect Success");
	}
	catch (Exception exp)
	{
        Console.Write("DB Connect Failure");        
	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandling>();

app.MapControllers();

app.Run();
