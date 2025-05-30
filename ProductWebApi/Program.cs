using ProductWebApi.Cosmos;
using ProductWebApi.Models;
using ProductWebApi.Services;
using ProductWebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.AddEnvironmentVariables().Build();

builder.Services.AddCors(c => c.AddPolicy("policy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.Configure<DataAccessClientSettings>(configuration.GetSection(nameof(DataAccessClientSettings)));
builder.Services.Configure<ImageSettings>(configuration.GetSection(nameof(ImageSettings)));

// Add services to the container.
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddSingleton<DataAccessClient>();

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

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
