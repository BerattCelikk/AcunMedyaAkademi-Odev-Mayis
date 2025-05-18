using Business;
using Business.Rules;          
using Core.Exceptions.Extensions;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Repositories ve Business servislerini ekle
builder.Services.AddRepositoriesServices(builder.Configuration);
builder.Services.AddBusinessServices();

// Business Rules s�n�flar�n� DI konteynerine ekle
builder.Services.AddScoped<ApplicantBusinessRules>();
builder.Services.AddScoped<BootcampBusinessRules>();
builder.Services.AddScoped<ApplicationBusinessRules>();
builder.Services.AddScoped<BlacklistBusinessRules>();

// Controller, Swagger vb.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddScoped => //Her Http request i�in bir kez olu�turulur
// AddSingleton   => Uygulama ba�lad���nda bir kez olu�turulur. Cache i�lemleri Config ayarlar�n� y�neten servisler
// AddTransient => Her kullan�mda yeni bir nesne olu�turur.EmailSenderService

// Uygulamay� yap�land�r�r
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleware();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

app.UseRouting();

app.MapControllers();

app.Run();
