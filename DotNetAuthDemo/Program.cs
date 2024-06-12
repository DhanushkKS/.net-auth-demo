using System.Security.Claims;
using DotNetAuthDemo.Data;
using DotNetAuthDemo.Entities;
using DotNetAuthDemo.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<TDbContext>(
    op=>op.UseNpgsql(
        configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly(typeof(TDbContext).Assembly.GetName().Name)));

//Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie();



// builder.Services.AddIdentityCore<Person>()
//     .AddEntityFrameworkStores<TDbContext>()
//     .AddApiEndpoints();

builder.Services.AddIdentityApiEndpoints<Person>()
    .AddEntityFrameworkStores<TDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.MapGet("users/me", async (ClaimsPrincipal claims,TDbContext context) =>
{
    string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    return await context.Users.FindAsync(userId);
}).RequireAuthorization();
app.MapIdentityApi<Person>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();