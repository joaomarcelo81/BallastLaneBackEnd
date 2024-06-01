using BallastLaneBackEnd.Infra;
using BallastLaneBackEnd.Infra.Initializer;
using Microsoft.EntityFrameworkCore;
using BallastLaneBackEnd.CrossCutting.IoC;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.OpenApi.Models;
//using BallastLaneBackEnd.Api.Middleware;
using BallastLaneBackEnd.Api.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BallastLaneBackEnd.Api.Validation;

var builder = WebApplication.CreateBuilder(args);





IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
var settings = config.GetRequiredSection("Settings").Get<Settings>();

builder.Services.AddSingleton(settings);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<SchoolContext>(options =>
//    options.UseInMemoryDatabase("InMemoryDb"));

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var DbPath = System.IO.Path.Join(path, "School.db");

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlite($"Data Source={DbPath}"));




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new()
{
    Title = "BallastLane School Api",
    Version = "v1",
    Contact = new OpenApiContact()
    {
        Name = "João",
        Email = "Joaomarcelo@teste.com"

    },
    Description = "API for the Proposed Challenge for the Offered Position\r\nDon't forget to insert the Apikey: 414fde74-d5e6-48ab-8063-9111c6b74d71",
});
    c.EnableAnnotations();
    c.AddSecurityDefinition("X-API-Key", new OpenApiSecurityScheme
    {
        Name = "X-API-Key",
        In = ParameterLocation.Header,
        Scheme = "X-API-Key",
        Type = SecuritySchemeType.ApiKey,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "X-API-Key" }
            },
            new List<string>()
        }
    });
});

builder.Services.AddSharedServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddDbContext<SchoolContext>(options =>
//     options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiKeyPolicy", policy =>
    {
        policy.AddAuthenticationSchemes(new[] { JwtBearerDefaults.AuthenticationScheme });
        policy.Requirements.Add(new ApiKeyRequirement());
    });

});
builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SchoolContext>();
    context.Database.EnsureCreated(); // Ensure the database is created
    DbInitializer.Initialize(context);
}




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
