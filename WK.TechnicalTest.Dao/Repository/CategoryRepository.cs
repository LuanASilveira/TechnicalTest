using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.BLL.Interfaces.Repository;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.DAO.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataDbContext db) : base(db)
        {
        }

        public async Task<bool> CheckDuplicatedName(string name, long? id)
        {
            var query = DbSet.Where(c => c.Name == name).AsQueryable();

            if (id.HasValue && id.Value > 0)
                query = query.Where(c => c.Id != id.Value);

            return await query.AnyAsync();
        }

        public async Task<string> GetNameById(long id)
        {
            return await DbSet.Where(c => c.Id == id)
                              .Select(c => c.Name)
                              .FirstOrDefaultAsync();
        }
    }
}
