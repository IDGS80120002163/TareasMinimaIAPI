using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TareasMinimaIAPI.Models
{
    public class Tarea
    {
        [Key]
        public Guid TareaId { get; set; }
        //Atributo de llave foránea
        [ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        //Atributo de relación
        public virtual Categoria Categoria { get; set; }
        
        [NotMapped]//Evita que este atributo "Resumen" sea mapeado hacia la BD
        public string Resumen {  get; set; }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}
