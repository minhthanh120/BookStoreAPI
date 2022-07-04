using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnnection' not found.");
bool IsServerConnected(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }
}
if (IsServerConnected(connectionString))
{
    List<string> originDomain = builder.Configuration.GetSection("FrontEndDomain").GetChildren()?.Select(x => x.Value)?.ToList();
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("*")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                          });
    });

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddScoped<IUserService, UserDAL>();
    builder.Services.AddScoped<IData<Author>, AuthorDAL>();
    builder.Services.AddScoped<IData<Book>, BookDAL>();
    builder.Services.AddScoped<IData<Category>, CategoryDAL>();
    //builder.Services.AddScoped<IConfiguration, Configuration>();
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
    app.UseAuthentication(); ;

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
else
{
    throw new Exception("Open MSSQL server");
}