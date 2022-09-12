using System.ComponentModel;

namespace WK.TechnicalTest.Api.ViewModel.Product
{
    public class ProductResponseViewModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        [DisplayName("Nome Categoria")]
        public string CategoryName { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Preço")]
        public string Price { get; set; }
    }
}
