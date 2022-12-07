using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mongo_MFlix_API.Models;
using Mongo_MFlix_API.Services;
using MongoDB.Bson.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//----------------------------------------------------
//----------------------------------------------------
// mongo
ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.Configure<MFlix_DBSettings>(configuration.GetSection("MFlix_DBSettings"));
builder.Services.AddSingleton<IMFlix_DBSettings>(x => x.GetRequiredService<IOptions<MFlix_DBSettings>>().Value);
//builder.Services.AddSingleton<IMFlix_DBSettings, MFlix_DBSettings>();
builder.Services.AddScoped<MFlix_Service>();


BsonClassMap.RegisterClassMap <MFlix_Collection>(cm =>
{
    cm.AutoMap();
    cm.SetIgnoreExtraElements(true);
});
//----------------------------------------------------
//----------------------------------------------------

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
