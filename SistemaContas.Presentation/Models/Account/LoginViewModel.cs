using System.ComponentModel.DataAnnotations;

namespace SistemaContas.Presentation.Models.Account
{

    /// <summary>
    /// Modelo de dados para o form de login 
    /// </summary>
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage ="Por favor, informe um endereço de email válido.")]
        [Required (ErrorMessage = "Por favor, informe seu email de acesso")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe o máximo {1} caracteres.")]
        [Required (ErrorMessage = "Por favor, informe sua seha de acesso")]
        public string? Senha { get; set; }
    }
}
