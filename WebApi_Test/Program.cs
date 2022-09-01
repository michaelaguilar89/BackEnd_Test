using Microsoft.EntityFrameworkCore;
using WebApi_Test.Interfaces;
using WebApi_Test.Mapping;
using WebApi_Test.Models;
using WebApi_Test.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<testContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//add automapper
var mapper =MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//add repositorys and interface
builder.Services.AddScoped<IClients, Clients_Repository>();
builder.Services.AddScoped<IUsers, Users_Repository>();
builder.Services.AddScoped<IProducts,Products_Repository>();
builder.Services.AddScoped<ISales, Sales_Repository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

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
