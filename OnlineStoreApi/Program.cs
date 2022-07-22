using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Services.Impl;
using Services.Interfaces;
using OnlineStoreApi;
using OnlineStore.Repo.Interfaces;
using OnlineStore.Repo.Impl;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


var connString = builder.Configuration.GetConnectionString("OnlineStoreDb");

// Add services to the container.
builder.Services.AddDbContext<OnlineStoreContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStoreDb")));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
                options => {
                  options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                  });

                  options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                        },
                        new string[] { }
                    }
                    });
                });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                  options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "https://localhost:7125",
                    ValidAudience = "https://localhost:7125",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HSFVBHASTGSHDVASDS"))
                  };
                });

builder.Services.AddTransient<IProductInterface, ProductService>();
builder.Services.AddTransient<IManagerInterface, ManagerService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IManagerRepository, ManagerRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
