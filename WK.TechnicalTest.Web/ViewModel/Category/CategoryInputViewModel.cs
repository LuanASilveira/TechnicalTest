using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WK.TechnicalTest.Web.ViewModel.Category
{
    public class CategoryInputViewModel
    {
        public long Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "Nome deve conter no máximo 150 caracteres.")]
        public string Name { get; set; }
    }
}
