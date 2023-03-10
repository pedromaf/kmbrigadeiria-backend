using KMBrigadeiria.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region DB Configuration
string mySQLConnectionString = builder.Configuration.GetConnectionString("KMBrigadeiriaConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

// Connecting with MySQL database.
builder.Services.AddDbContext<KMContext>(opts => opts.UseLazyLoadingProxies().UseMySql(mySQLConnectionString, serverVersion));
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
