using Microsoft.EntityFrameworkCore;
using NetflixAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Configuration;
using System.Globalization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add authentication
// Configure JWT authentication
    var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };
        });

// Add services to the container.

builder.Services.AddControllers()
    .AddXmlDataContractSerializerFormatters(); //XmlSerializer doesn't like lists
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<NetflixContext>(opt =>
    opt.UseSqlServer("Server=localhost;Database=Netflix;User Id=APIUSER;Password=ASDF;TrustServerCertificate=true;"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();