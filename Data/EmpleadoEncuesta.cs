using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEncuestasAPI.Data
{
    [Table("EmpleadosEncuesta")]
    public class EmpleadoEncuesta
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Zona { get; set; }
        public string Area { get; set; }

        // public virtual IList<Encuesta> EncuestasAtendidas { get; set;}
    }
}
