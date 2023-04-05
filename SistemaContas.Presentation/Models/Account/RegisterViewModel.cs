using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SistemaContas.Presentation.Models.Account
{

    /// <summary>
    /// Modele de dados para fomulário de cadastro de usuario
    /// </summary>
    public class RegisterViewModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe o máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor informe o nome.")]
        public string? Nome { get; set; }
        
        [Required(ErrorMessage = "Por favor informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
         ErrorMessage = "Por favor, informe uma senha com pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número, 1 símbolo e com no mínimo 8 caracteres.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem, favor verificar!")]
        [Required(ErrorMessage = "Por favor confirme a senha.")]
        public string? SenhaConfirmacao { get; set;}
    }
}
