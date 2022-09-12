using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<string> GetNameById(long id);
        Task<bool> CheckDuplicatedName(string name, long? id);
    }
}
