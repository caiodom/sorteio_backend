using System.ComponentModel.DataAnnotations;

namespace Sorteio.Api.Models.Auth.Deprecated
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name é obrigatório!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password é obrigatório!")]
        public string? Password { get; set; }
    }
}
