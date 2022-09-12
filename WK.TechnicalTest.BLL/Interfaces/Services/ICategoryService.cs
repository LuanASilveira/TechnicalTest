using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<string>> Add(Category category);
        Task<IEnumerable<string>> Update(Category category);
        Task Delete(long id);
        Task<Category> GetById(long id);
        Task<string> GetNameById(long id);
        Task<bool> CheckDuplicatedName(string name, long? id);
    }
}
