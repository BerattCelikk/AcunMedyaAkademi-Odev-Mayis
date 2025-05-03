using Business;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesServices(builder.Configuration);
builder.Services.AddBusinessServices();


//AddScoped => //Her Http request i�in bir kez olu�turulur
//AddSingleton   => Uygulama ba�lad���nda bir kez olu�turulur. Cache i�lemleri Config ayarlar�n� y�neten servisler
//AddTransiet => Her kullan�mda yeni bir nesne olu�turur.EmailSenderService

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.


// Uygulamay� yap�land�r�r
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Configure the HTTP request pipeline.



app.Run();
