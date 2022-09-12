using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WK.TechnicalTest.Api.ViewModel.Category
{
    public class CategoryInputViewModel
    {

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "Nome deve conter no máximo 150 caracteres.")]
        public string Name { get; set; }
    }
}
