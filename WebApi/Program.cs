using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(); // Application katmanýndaki servisleri ekle // Örneðin MediatR veya Diðer servisler
builder.Services.AddPersistenceServices(builder.Configuration); // Persistence katmanýndaki servisleri ekle // Örneðin DbContext ve Repositoryler

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsProduction()) // Üretim ortamýnda özel hata yakalama middleware'ini ekle
{ 
    app.ConfigureCustomExceptionMiddleware(); // Özel hata yakalama middleware'ini ekle
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
