using AppEncuestasAPI.Data;
using AppEncuestasAPI.Models.EmpleadosEncuesta;
using System.ComponentModel.DataAnnotations;

namespace AppEncuestasAPI.Models.Encuestas
{
    public class EncuestaReadOnlyDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Int16 CalificaTiempo { get; set; }
        public Int16 CalificaInformacion { get; set; }
        public Int16 CalificaTrato { get; set; }
        public Byte TramiteSolucionado { get; set; }
        public DateTime Ingresada { get; set; }
        public int EmpleadoEncuestaId { get; set; }
        public string? Comentario { get; set; }               
        // public virtual EmpleadoEncuesta? AtendidoPor { get; set; }
    }
}