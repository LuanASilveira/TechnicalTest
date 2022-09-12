using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(long id);
        Task<IEnumerable<string>> Add(Product product);
        Task<IEnumerable<string>> Update(Product product);
        Task DeleteByCategoryId(long categoryId);
        Task Delete(long id);
    }
}
