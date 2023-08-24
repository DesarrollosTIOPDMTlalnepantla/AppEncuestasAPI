using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEncuestasAPI.Data
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? Departamento { get; set; }
        public string? Direccion { get; set; }
        public string? Foto { get; set; }
    }
}