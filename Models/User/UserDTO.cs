namespace AppEncuestasAPI.Models.User
{
    public class UserDTO : LoginUserDTO
    {
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Role  { get; set; }
    }
    public class LoginUserDTO
    {
        public string? Email { get; set; }
        public string? Contrasenia { get; set; }
    }
}    