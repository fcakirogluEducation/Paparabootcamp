using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TokenAuth.API.Controllers;
using TokenAuth.API.Requirements;
using TokenAuth.Repository.Models;
using TokenAuth.Repository.Models.ManyToMany;
using TokenAuth.Service.BackgroundServices;
using TokenAuth.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IdentityService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
        sqloptions => { sqloptions.MigrationsAssembly("TokenAuth.Repository"); });
});
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
    //options.User.AllowedUserNameCharacters= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
}).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddAuthentication(options =>
{
    //schema

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    var signatureKey = builder.Configuration.GetSection("TokenOptions")["SignatureKey"]!;
    var issuer = builder.Configuration.GetSection("TokenOptions")["Issuer"]!;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidIssuer = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey))
    };
});

//Claim-Base Authorization
//Policy-Base Authorization


builder.Services.AddScoped<IAuthorizationHandler, BirthDateOver18CheckRequirementHandler>();
builder.Services.AddAuthorization(options =>
{
    //claim based
    options.AddPolicy("BirthDateCheck", x => { x.RequireClaim(ClaimTypes.DateOfBirth); });

    // policy based
    options.AddPolicy("BirthDateCheckOver18", options => { options.AddRequirements(new BirthDateOver18Check()); });
});


builder.Services.AddHostedService<UserEmailSenderBackgroundService>();
builder.Services.AddHostedService<ProductCountEmailSenderBackgroundService>();
builder.Services.AddSingleton<Bus>();
var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    //var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


    //var teacher = new Teacher
    //{
    //    Name = "Teacher1",
    //    Students =
    //    [
    //        new Student { Name = "Student1" },
    //        new Student { Name = "Student2" }
    //    ]
    //};


    //appDbContext.Teachers.Add(teacher);
    //appDbContext.SaveChanges();


    //var hasTeacher = appDbContext.Teachers.Include(x => x.Students).First(x => x.Name == "Teacher1");

    //if (hasTeacher.Students is not null)
    //{
    //    hasTeacher.Students.Add(new() { Name = "Student 3" });

    //    hasTeacher.Students.Add(new() { Name = "Student 4" });
    //}


    //appDbContext.Teachers.Update(teacher);
    //appDbContext.SaveChanges();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


List<int> numbers = new();
numbers.Add(1);
numbers.Add(2);

numbers.Add(3);
foreach (var item in numbers)
{
}

// FIFO
Queue<int> numbersQueue = new();
numbersQueue.Enqueue(1);
var numberOne = numbersQueue.Dequeue();
// LIFO
Stack<int> numbersStack = new();