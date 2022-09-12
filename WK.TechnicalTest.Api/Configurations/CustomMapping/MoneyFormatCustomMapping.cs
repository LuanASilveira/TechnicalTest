using AutoMapper;
using WK.TechnicalTest.Api.ViewModel.Product;
using WK.TechnicalTest.BLL.Extensions;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.Api.Configurations.CustomMapping
{
    public class MoneyFormatCustomMapping : IValueResolver<Product, ProductResponseViewModel, string>
    {
        public string Resolve(Product source, ProductResponseViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Price.ToMoneyString();
        }
    }
}
