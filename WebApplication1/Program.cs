using Microsoft.EntityFrameworkCore;
using PersonaTest.Infrastucture;
using PersonaTest.Infrastucture.Repositories.Interfaces;
using PersonaTest.Infrastucture.Repositories;
using PersonaTest.Core.Services.Interfaces;
using PersonaTest.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("ConnectionString:PersonaDB");
builder.Services.AddDbContext<PersonaTestContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaService, PersonaService>();


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
