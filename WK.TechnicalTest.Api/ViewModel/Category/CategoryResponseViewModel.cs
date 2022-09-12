using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WK.TechnicalTest.Api.ViewModel.Category
{
    public class CategoryResponseViewModel
    {
        public long Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
