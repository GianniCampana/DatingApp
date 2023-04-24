using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//fornisco la stringa di connessione che mi permetterà di connettermi al db
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//aggiungo l'AddCorsa per il dire al browser di fidarsi del server
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
//in questo punto sempre per il problema della Cors aggiungo questa riga di codice che dice che va bene qualsiasi header di qualsiasi metodo di qualsiasi origine
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.MapControllers();

app.Run();
