using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WK.TechnicalTest.Api.ViewModel.Product
{
    public class ProductInputViewModel
    {
        [DisplayName("Id da Categoria")]
        [Required(ErrorMessage = "Id da Categoria é obrigatório.")]
        public long CategoryId { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "Nome deve conter no máximo 150 caracteres.")]
        public string Name { get; set; }
        [DisplayName("Preço")]
        [Required(ErrorMessage = "Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser maior que 0.")]
        public decimal Price { get; set; }
    }
}
