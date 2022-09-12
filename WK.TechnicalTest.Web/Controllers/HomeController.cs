using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Web.ViewModel.Category;
using WK.TechnicalTest.Web.ViewModel.Pages;
using WK.TechnicalTest.Web.ViewModel.Product;

namespace WK.TechnicalTest.Web.Controllers
{
    public class HomeController : MainController
    {

        public HomeController( IApiService apiService) : base(apiService)
        {
        }

        public async Task<IActionResult> Index(string errors)
        {
            HomeViewModel viewModel = await GetViewModel(errors);

            return View(viewModel);
        }
    }
}