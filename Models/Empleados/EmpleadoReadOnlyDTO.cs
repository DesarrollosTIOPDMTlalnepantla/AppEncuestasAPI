namespace AppEncuestasAPI.Models.Empleados
{
    public class EmpleadoReadOnlyDTO : BaseDTO
    {
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? Departamento { get; set; }
        public string? Direccion { get; set; }
        public string? Foto { get; set; }
    }
}

