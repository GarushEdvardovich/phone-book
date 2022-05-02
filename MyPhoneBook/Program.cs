using Microsoft.EntityFrameworkCore;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Bll.Services;
using MyPhoneBook.Controllers.Models;
using System.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//builder.Services.AddDbContext<MyPhoneBookContext>(options =>
//{
//    var host = builder.Configuration.GetValue<string>("host");
//    var port = builder.Configuration.GetValue<string>("port");
//    var username = builder.Configuration.GetValue<string>("username");
//    var password = builder.Configuration.GetValue<string>("password");
//    var database = builder.Configuration.GetValue<string>("database");

//    var connstr = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

//    options.UseNpgsql(connstr);
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IContactService, ContactService>();
//builder.Services.AddDbContext<DbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
