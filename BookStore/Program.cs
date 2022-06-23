using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models.Entities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BookStoreConnection") ?? throw new InvalidOperationException("Connection string 'BookStoreContextConnection' not found.");



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserDAL>();
builder.Services.AddScoped<IData<Author>, AuthorDAL>();
builder.Services.AddScoped<IData<Book>, BookDAL>();
builder.Services.AddScoped<IData<Category>, CategoryDAL>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Hỗ trợ json cho webapi
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.Run();
