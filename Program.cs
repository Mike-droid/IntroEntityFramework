using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.Run();
