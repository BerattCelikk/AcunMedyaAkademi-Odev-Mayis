
//Uygulama olu�turucu 
var builder = WebApplication.CreateBuilder(args);

//Controller servisini ekler
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

// Configure the HTTP request pipeline.

//Http isteklerini controller'a y�nlendirir.
app.MapControllers();
//Uygulamay� �al��t�r�r
app.Run();

