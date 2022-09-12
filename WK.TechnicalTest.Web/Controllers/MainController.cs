using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Web.ViewModel.Category;
using WK.TechnicalTest.Web.ViewModel.Pages;
using WK.TechnicalTest.Web.ViewModel.Product;

namespace WK.TechnicalTest.Web.Controllers
{
    public class MainController : Controller
    {
        private readonly IApiService _apiService;

        public MainController(IApiService apiService)
        {
            _apiService = apiService;
        }

        protected async Task<HomeViewModel> GetViewModel(string errors = null)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryResponseViewModel>>(await _apiService.GetAll("category"));
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductResponseViewModel>>(await _apiService.GetAll("product"));

            return new HomeViewModel()
            {
                Categories = categories,
                Products = products,
                SelectCategory = new SelectList(categories, "Id", "Name"),
                Errors = errors
            };
        }
    }
}
