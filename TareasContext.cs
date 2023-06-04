using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;

namespace proyectoEF;

public class TareasContext : DbContext
{
  public DbSet<Categoria> Categorias { get; set; }
  public DbSet<Tarea> Tareas { get; set; }
  public TareasContext(DbContextOptions<TareasContext> options) :base(options) {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Categoria> categoriasInit = new List<Categoria>();
    categoriasInit.Add(new Categoria() {
      CategoriaId = Guid.Parse("6ae7acaa-9324-486f-976c-70b93b5a5eed"),
      Nombre = "Actividades pendientes",
      Peso = 20
    });

    categoriasInit.Add(new Categoria() {
      CategoriaId = Guid.Parse("6ae7acaa-9324-486f-976c-70b93b5a5e02"),
      Nombre = "Actividades personales",
      Peso = 50
    });

    categoriasInit.Add(new Categoria() {
      CategoriaId = Guid.Parse("6ae7acaa-9324-486f-976c-5ac93b5a5e02"),
      Nombre = "Cosas trabajo",
      Peso = 100
    });

    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("Categoria");
      categoria.HasKey(key => key.CategoriaId);

      categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Descripcion).IsRequired(false);
      categoria.Property(p => p.Peso);

      categoria.HasData(categoriasInit);
    });

    List<Tarea> tareasInit = new List<Tarea>();
    tareasInit.Add(new Tarea() {
      TareaId = Guid.Parse("8de7acaa-9324-486f-976c-70b93b5a5eed"),
      CategoriaId = Guid.Parse("6ae7acaa-9324-486f-976c-70b93b5a5eed"),
      PrioridadTarea = Prioridad.Media,
      Titulo = "Pago de servicios públicos",
      FechaCreacion = DateTime.Now
    });

    tareasInit.Add(new Tarea() {
      TareaId = Guid.Parse("9ce7acaa-9324-486f-976c-70b93b5a5eed"),
      CategoriaId = Guid.Parse("6ae7acaa-9324-486f-976c-70b93b5a5e02"),
      PrioridadTarea = Prioridad.Baja,
      Titulo = "Terminar serie en Netflix",
      FechaCreacion = DateTime.Now
    });

    tareasInit.Add(new Tarea() {
      TareaId = Guid.Parse("9ce7acaa-1234-486f-976c-70b93b5a5eed"),
      CategoriaId = Guid.Parse("6ae7acaa-9324-486f-976c-5ac93b5a5e02"),
      PrioridadTarea = Prioridad.Alta,
      Titulo = "Reparar bug de React.js",
      FechaCreacion = DateTime.Now
    });

    modelBuilder.Entity<Tarea>(tarea =>
    {
      tarea.ToTable(("Tarea"));
      tarea.HasKey(key => key.TareaId);

      tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

      tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(p => p.Descripcion).IsRequired(false);
      tarea.Property(p => p.PrioridadTarea);
      tarea.Property(p => p.FechaCreacion);
      tarea.Property(p => p.Puntos);

      tarea.Ignore(p => p.Resumen);

      tarea.HasData(tareasInit);
    });
  }
}
