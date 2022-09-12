using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Web.ViewModel.Category;
using WK.TechnicalTest.Web.ViewModel.Pages;
using WK.TechnicalTest.Web.ViewModel.Product;

namespace WK.TechnicalTest.Web.Controllers
{
    public class CategoryController : MainController
    {
        private readonly IApiService _apiService;

        public CategoryController(IApiService apiService) : base(apiService)
        {
            _apiService = apiService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryInputViewModel categoryInputViewModel)
        {
            IEnumerable<string> errors;
            if (categoryInputViewModel.Id > 0)
            {
                errors = await _apiService.Update("category", categoryInputViewModel.Id, JsonConvert.SerializeObject(categoryInputViewModel));
            }
            else
            {
                errors = await _apiService.Add("category", JsonConvert.SerializeObject(categoryInputViewModel));
            }

            return RedirectToAction("Index", "Home", string.Join("<br/>", errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(long categoryId)
        {
            CategoryResponseViewModel category = (CategoryResponseViewModel)await _apiService.GetById("category", typeof(CategoryResponseViewModel), categoryId);

            return new JsonResult(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(long categoryId)
        {
            bool success = await _apiService.Delete("category", categoryId);

            return new JsonResult(new { success });
        }

    }
}
