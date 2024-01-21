using Microsoft.Extensions.FileProviders;
using PaparaApp.API.Extensions;
using PaparaApp.API.Filters;
using PaparaApp.API.Models.Products;
using PaparaApp.API.TwoDay;

var builder = WebApplication.CreateBuilder(args);


// add behavior to the DI container
builder.Services.AddProductDIContainer();
builder.Services.AddControllers(x => { x.Filters.Add<NotFoundActionFilter>(); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddAutoMapper(typeof(Program)); // IMapper
builder.Services.AddScoped<NotFoundActionFilter>();


var app = builder.Build();
app.AddExceptionMiddleware();

//app.UseMiddleware<IpCheckMiddleware>();
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 1 request");
//    await next();
//    Console.WriteLine("Middleware 1 response");
//});
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 2 request");
//    await next();
//    Console.WriteLine("Middleware 2 response");
//});

//app.Run(context =>
//{
//    Console.WriteLine("Middleware Run request");
//    return Task.CompletedTask;
//});


// Configure the HTTP request pipeline.
app.AddDefaultMiddlewaresExt();

var writeAttribute = new WriteAttribute();
writeAttribute.WriteComputerAttribute();

app.Run();