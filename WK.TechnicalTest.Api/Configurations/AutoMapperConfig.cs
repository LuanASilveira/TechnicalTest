using AutoMapper;
using WK.TechnicalTest.Api.Configurations.CustomMapping;
using WK.TechnicalTest.Api.ViewModel.Category;
using WK.TechnicalTest.Api.ViewModel.Product;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryResponseViewModel>();
            CreateMap<CategoryInputViewModel, Category>();
            CreateMap<Product, ProductResponseViewModel>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom<CategoryNameCustomMapping>())
                                                          .ForMember(dest => dest.Price, opt => opt.MapFrom<MoneyFormatCustomMapping>());
            CreateMap<ProductInputViewModel, Product>();
        }
    }
}
