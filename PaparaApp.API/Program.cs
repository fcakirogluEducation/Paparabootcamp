using Microsoft.Extensions.FileProviders;
using PaparaApp.API.Extensions;
using PaparaApp.API.Models.Products;
using PaparaApp.API.TwoDay;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//
// DI Container Framework/Library - Inversion Of Control (IoC) Framework/Library


// Lifetime of the object => Singleton, Scoped, Transient

builder.Services.AddProductDIContainer();

// Helper class Singleton

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddAutoMapper(typeof(Program)); // IMapper
var app = builder.Build();
// Configure the HTTP request pipeline.
app.AddDefaultMiddlewaresExt();

var writeAttribute = new WriteAttribute();
writeAttribute.WriteComputerAttribute();

app.Run();