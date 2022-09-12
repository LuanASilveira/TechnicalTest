using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Web.ViewModel.Category;
using WK.TechnicalTest.Web.ViewModel.Pages;
using WK.TechnicalTest.Web.ViewModel.Product;

namespace WK.TechnicalTest.Web.Controllers
{
    public class ProductController : MainController
    {
        private readonly IApiService _apiService;

        public ProductController(IApiService apiService) : base(apiService)
        {
            _apiService = apiService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductInputViewModel productInputViewModel)
        {
            IEnumerable<string> errors;
            if (productInputViewModel.Id > 0)
            {
                errors = await _apiService.Update("product", productInputViewModel.Id, JsonConvert.SerializeObject(productInputViewModel));
            }
            else
            {
                errors = await _apiService.Add("product", JsonConvert.SerializeObject(productInputViewModel));
            }

            return RedirectToAction("Index", "Home", string.Join("<br/>", errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(long productId)
        {
            ProductResponseViewModel product = (ProductResponseViewModel)await _apiService.GetById("product", typeof(ProductResponseViewModel), productId);

            return new JsonResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            bool success = await _apiService.Delete("product", productId);

            return new JsonResult(new { success });
        }

    }
}
