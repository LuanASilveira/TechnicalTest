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
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductService _productService;

        public CategoryService(ICategoryRepository categoryRepository, IProductService productService)
        {
            _categoryRepository = categoryRepository;
            _productService = productService;
        }

        public async Task<IEnumerable<string>> Add(Category category)
        {
            IEnumerable<string> validation = await ExecuteValidation(new CategoryValidation(this), category);
            if (validation.Any())
                return validation;

            try
            {
                await _categoryRepository.Add(category);
            }
            catch
            {
                return new string[] { "Ocorreu um erro ao salvar o registro!" };
            }

            return Array.Empty<string>();
        }

        public async Task<bool> CheckDuplicatedName(string name, long? id)
        {
            return await _categoryRepository.CheckDuplicatedName(name, id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(long id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<string> GetNameById(long id)
        {
            return await _categoryRepository.GetNameById(id);
        }

        public async Task Delete(long id)
        {
            await _productService.DeleteByCategoryId(id);

            await _categoryRepository.Delete(id);
        }

        public async Task<IEnumerable<string>> Update(Category category)
        {
            IEnumerable<string> validation = await ExecuteValidation(new CategoryValidation(this), category);
            if (validation.Any())
                return validation;

            try
            {
                await _categoryRepository.Update(category);
            }
            catch
            {
                return new string[] { "Ocorreu um erro ao salvar o registro!" };
            }

            return Array.Empty<string>();
        }
    }
}
