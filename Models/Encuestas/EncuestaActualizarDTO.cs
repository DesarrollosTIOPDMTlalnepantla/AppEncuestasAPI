namespace AppEncuestasAPI.Models.Encuestas
{
    public class EncuestaActualizarDTO
    {
        public int EncuestaId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public byte CalificaTiempo { get; set; }
        public byte CalificaInformacion { get; set; }
        public byte CalificaTrato { get; set; }
        public bool? TramiteSolucionado { get; set; }
        public int EmpleadoEncuestaId { get; set; }
    }
}
