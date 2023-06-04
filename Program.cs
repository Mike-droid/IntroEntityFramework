using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF;
using proyectoEF.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("conexionTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/v1/tareas", async ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.Tareas); //* Todas las tareas

  //* Podemos usar Linq
  //return Results.Ok(dbContext.Tareas.Where(tarea => tarea.PrioridadTarea == proyectoEF.Models.Prioridad.Baja));
});

app.MapGet("/api/v1/tareas/prioridad/{id}", async ([FromServices] TareasContext dbContext, int id) =>
{
  var data = dbContext.Tareas.Include(tarea => tarea.Categoria).Where(tarea => (int)tarea.PrioridadTarea == id);
  return Results.Ok(data);
});

app.MapPost("/api/v1/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  tarea.TareaId = Guid.NewGuid();
  tarea.FechaCreacion = DateTime.Now;
  await dbContext.AddAsync(tarea);

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.Run();
