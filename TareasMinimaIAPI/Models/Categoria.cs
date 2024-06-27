using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TareasMinimaIAPI.Models
{
    public class Categoria
    {
        [Key] //Especifica propiedad de llave primaria
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(150)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        //NUEVO CAMPO
        public int Peso {  get; set; }

        //Atributo de relación
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
