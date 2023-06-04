using System.Text.Json.Serialization;

namespace proyectoEF.Models;

public class Categoria
{
  public Guid CategoriaId { get; set; }
  public string Nombre { get; set; }
  public string Descripcion { get; set; }
  public int Peso { get; set; }

  [JsonIgnore] //* funciona cuando usamos 'Include' en Linq
  public virtual ICollection<Tarea> Tareas {get; set;}
}
