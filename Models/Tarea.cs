using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;
    public class Tarea{
        //[Key]
        public Guid TareaId { get; set; }
        //[ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }
       // [Required]
       // [MaxLength(150)]
        public string Nombre { get; set; }
        public string Apellido {get; set;}
        public string Descripcion {get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Categoria Categoria { get; set; }
    }

   public enum  Prioridad{
    Alta,
    Media,
    Baja
}


