using Business;
using Business.Rules;          
using Core.Exceptions.Extensions;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Repositories ve Business servislerini ekle
builder.Services.AddRepositoriesServices(builder.Configuration);
builder.Services.AddBusinessServices();

// Business Rules sýnýflarýný DI konteynerine ekle
builder.Services.AddScoped<ApplicantBusinessRules>();
builder.Services.AddScoped<BootcampBusinessRules>();
builder.Services.AddScoped<ApplicationBusinessRules>();
builder.Services.AddScoped<BlacklistBusinessRules>();

// Controller, Swagger vb.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddScoped => //Her Http request için bir kez oluþturulur
// AddSingleton   => Uygulama baþladýðýnda bir kez oluþturulur. Cache iþlemleri Config ayarlarýný yöneten servisler
// AddTransient => Her kullanýmda yeni bir nesne oluþturur.EmailSenderService

// Uygulamayý yapýlandýrýr
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
