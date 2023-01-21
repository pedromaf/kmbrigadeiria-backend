using KMBrigadeiria.Data;
using KMBrigadeiria.Repositories;
using KMBrigadeiria.Repositories.Interfaces;
using KMBrigadeiria.Services;
using KMBrigadeiria.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Service Layer
builder.Services.AddScoped<IClientService, ClientService>();
#endregion

#region Repository Layer
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
#endregion

#region Authentication
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(token =>
{
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0j928jef09823jf9i0djf09asijfpjsnd0f1n9248un08rn3984n3hjnxoif")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
#endregion

#region DB Configuration
string mySQLConnectionString = builder.Configuration.GetConnectionString("KMBrigadeiriaConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
