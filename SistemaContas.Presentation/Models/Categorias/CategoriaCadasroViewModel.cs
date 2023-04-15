using SistemaContas.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaContas.Presentation.Models.Categorias
{

    /// <summary>
    /// Modelo de dados para capturar os campos do formulário da 
    /// página de cdadastro de categorias
    /// </summary>
    public class CategoriaCadasroViewModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{5,50}$",
            ErrorMessage = "Por favor, informe um nome válido de 8 a 20 caracteres.")]
        [Required(ErrorMessage  = "Por favor, informe o nome da categoria.")]
        public string? Nome  { get; set; }
        [Required(ErrorMessage = "Por favor, selecione o tipo da cartegoria.")]
        public TipoCategoria? Tipo { get; set; }
    }
}
