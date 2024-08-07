using Example.ApplicationLayer;
using Example.ApplicationLayer.Personnels;
using Example.Database;
using Example.Database.Repositories;
using Example.Database.Repositories.Personnels;
using Example.Database.UnitofWork;
using Example.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Log.Logger=new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("Logs/log.txt",
	rollingInterval:RollingInterval.Day)
	.CreateLogger();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<Context>()
	.AddDefaultTokenProviders();

var jwtSettings = builder.Configuration.GetSection("JWT");

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = jwtSettings.GetSection("Issuer").Value,
		ValidAudience = jwtSettings.GetSection("Audience").Value,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
	};
});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});


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

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandling>();

app.MapControllers();

app.Run();
