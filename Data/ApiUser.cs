using Microsoft.AspNetCore.Identity;
namespace AppEncuestasAPI.Data
{
    public class ApiUser : IdentityUser
    {
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
    }
}