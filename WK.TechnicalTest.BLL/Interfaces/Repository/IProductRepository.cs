using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task DeleteRange(IEnumerable<Product> products);
    }
}
