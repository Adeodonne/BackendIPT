using BackendIPT.BLL.Lab2;
using BackendIPT.BLL.Services.Lab4;
using BackendIPT.DAL.Persistance;
using BackendIPT.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddDbContext<IPTDBContext>((options) =>
{
    options.UseSqlServer(
        "Server=127.0.0.1;Database=IPTDB;User Id=sa;Password=Admin@1234;MultipleActiveResultSets=true;TrustServerCertificate=True");
});
builder.Services.AddControllers();
builder.Services.AddScoped<IMD5Service, Md5Service>();
builder.Services.AddScoped<IMD5Repository, MD5Repository>();
builder.Services.AddScoped<ICryptoService, CryptoService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program
{
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<IPTDBContext>();
    }
}