using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PaparaApp.API.Extensions;
using PaparaApp.API.Filters;
using PaparaApp.API.Models;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
// add in-memory cache
builder.Services.AddMemoryCache(options =>
{
    // options.SizeLimit = 200;
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});


// add behavior to the DI container
builder.Services.AddProductDIContainer();
builder.Services.AddControllers(x => { x.Filters.Add<NotFoundActionFilter>(); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddAutoMapper(typeof(Program)); // IMapper
builder.Services.AddScoped<NotFoundActionFilter>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.AddExceptionMiddleware();
// Configure the HTTP request pipeline.
app.AddDefaultMiddlewaresExt();


app.Run();