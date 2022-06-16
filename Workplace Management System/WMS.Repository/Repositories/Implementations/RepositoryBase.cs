using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CoreDbContext _coreDbContext;

        public RepositoryBase(CoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? 
                _coreDbContext.Set<T>()
                    .AsNoTracking() :
                _coreDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
                _coreDbContext.Set<T>()
                    .Where(expression).
                    AsNoTracking() :
                _coreDbContext.Set<T>()
                    .Where(expression);

        public void Create(T entity) =>
            _coreDbContext.Set<T>()
                .Add(entity);

        public void Update(T entity) =>
            _coreDbContext.Set<T>()
                .Update(entity);

        public void Delete(T entity) =>
            _coreDbContext.Set<T>()
                .Remove(entity);
    }
}
