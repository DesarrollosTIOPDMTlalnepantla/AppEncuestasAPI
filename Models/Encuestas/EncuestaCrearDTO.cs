using System.ComponentModel.DataAnnotations;

namespace AppEncuestasAPI.Models.Encuestas
{
    public class EncuestaCrearDTO
    {
        // [StringLength(50)]
        public string? Nombre { get; set; }
        // [StringLength(50)]
        public string? Telefono { get; set; }
        // [StringLength(50)]        
        public string? Email { get; set; }
        // [Required]
        public byte? CalificaTiempo { get; set; }
        // [Required]
        public byte? CalificaInformacion { get; set; }
        // [Required]
        public byte? CalificaTrato { get; set; }
        // [Required]
        public bool? TramiteSolucionado { get; set; }
        public int EmpleadoEncuestaId { get; set; }
        public string? Comentario { get; set; }             
    }
}
