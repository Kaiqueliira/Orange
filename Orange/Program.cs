using Microsoft.EntityFrameworkCore;
using Orange.Data;
using Orange.Repository;
using Orange.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("OrangeDB");
builder.Services.AddDbContext<OrangeContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITrailRepository, TrailRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
