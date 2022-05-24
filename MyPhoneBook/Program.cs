using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MyPhoneBook;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Bll.Services;
using MyPhoneBook.Controllers.Models;
using MyPhoneBook.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<MyPhoneBookContext>(
   options => options.UseNpgsql("name=ConnectionStrings:MyPhoneBookApiConection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IMyPhoneBookContext, MyPhoneBookContext>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();    
}


app.UseAuthorization();
Middleware(app, app.Environment);

app.UseAuthorization();
app.MapControllers();
app.Run();

void Middleware(IApplicationBuilder app, IWebHostEnvironment env)
{    
    app.UseStatusCodePagesWithReExecute("/Error");
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<StatusCodePagesMiddleware>();
    app.ConfigureExceptionHandler(env);
    
}