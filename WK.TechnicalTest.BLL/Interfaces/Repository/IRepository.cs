using System.Linq.Expressions;
using WK.TechnicalTest.Model;

namespace WK.TechnicalTest.BLL.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(long id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(long id);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
        Task<int> CountAsync();
    }
}
