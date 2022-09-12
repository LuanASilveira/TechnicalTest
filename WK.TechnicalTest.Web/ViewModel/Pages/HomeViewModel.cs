using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WK.TechnicalTest.Web.ViewModel.Category;
using WK.TechnicalTest.Web.ViewModel.Product;

namespace WK.TechnicalTest.Web.ViewModel.Pages
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryResponseViewModel> Categories { get; set; }
        public IEnumerable<ProductResponseViewModel> Products { get; set; }
        public CategoryInputViewModel InputCategory { get; set; }
        public ProductInputViewModel InputProduct { get; set; }
        public SelectList SelectCategory { get; set; } 
        public string Errors { get; set; }
    }
}
