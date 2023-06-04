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

app.MapPut("/api/v1/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{

  var tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual != null)
  {
    tareaActual.CategoriaId = tarea.CategoriaId;
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;
    tareaActual.Descripcion = tarea.Descripcion;
    tareaActual.Puntos = tarea.Puntos;

    await dbContext.SaveChangesAsync();
    return Results.Ok("Tarea actualizada");
  }

  return Results.NotFound("La tarea no fue encontrada");

});

app.MapDelete("/api/v1/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
  var tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual == null)
  {
    return Results.NotFound("La tarea no fue encontrada");
  }

  dbContext.Remove(tareaActual);
  await dbContext.SaveChangesAsync();

  return Results.Ok("Tarea eliminada");
});


app.Run();
