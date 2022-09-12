using WK.TechnicalTest.BLL.Interfaces.Repository;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.DAO.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataDbContext db) : base(db)
        {
        }

        public async Task DeleteRange(IEnumerable<Product> products)
        {
            Db.RemoveRange(products);
            await Db.SaveChangesAsync();
        }
    }
}
