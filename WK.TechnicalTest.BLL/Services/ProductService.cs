using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.BLL.Interfaces.Repository;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.BLL.Model.Validations;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<string>> Add(Product product)
        {
            IEnumerable<string> validation = await ExecuteValidation(new ProductValidation(), product);
            if (validation.Any())
                return validation;

            try
            {
                await _productRepository.Add(product);
            }
            catch
            {
                return new string[] { "Ocorreu um erro ao salvar o registro!" };
            }

            return Array.Empty<string>();
        }

        public async Task Delete(long id)
        {
            await _productRepository.Delete(id);
        }

        public async Task DeleteByCategoryId(long categoryId)
        {
           IEnumerable<Product> categoryProducts = await _productRepository.Get(p => p.CategoryId == categoryId);
            await _productRepository.DeleteRange(categoryProducts);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(long id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IEnumerable<string>> Update(Product product)
        {
            IEnumerable<string> validation = await ExecuteValidation(new ProductValidation(), product);
            if (validation.Any())
                return validation;

            try
            {
                await _productRepository.Update(product);
            }
            catch
            {
                return new string[] { "Ocorreu um erro ao salvar o registro!" };
            }

            return Array.Empty<string>();
        }
    }
}
