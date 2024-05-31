using BallastLaneBackEnd.Infra;
using BallastLaneBackEnd.Infra.Initializer;
using Microsoft.EntityFrameworkCore;
using BallastLaneBackEnd.CrossCutting.IoC;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.OpenApi.Models;

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

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));
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
    Description = "Api para o Desafio proposto para vaga oferecida Não esquecer de inserir a Apikey: 414fde74-d5e6-48ab-8063-9111c6b74d71",
});
});

builder.Services.AddSharedServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddDbContext<SchoolContext>(options =>
//     options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));


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
