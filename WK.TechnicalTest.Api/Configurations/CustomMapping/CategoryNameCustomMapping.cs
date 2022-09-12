using AutoMapper;
using WK.TechnicalTest.Api.ViewModel.Product;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.Api.Configurations.CustomMapping
{
    public class CategoryNameCustomMapping : IValueResolver<Product, ProductResponseViewModel, string>
    {
        private ICategoryService _categoryService;
        public CategoryNameCustomMapping(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public string Resolve(Product source, ProductResponseViewModel destination, string destMember, ResolutionContext context)
        {
            return _categoryService.GetNameById(source.CategoryId).Result;
        }
    }
}
