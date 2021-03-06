using Microsoft.EntityFrameworkCore;
using WMS.Data.Entities;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{ // to be deleted
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CoreDbContext _context;
        private DbSet<T> _entities;
        string errorMessage = string.Empty;

        public Repository(CoreDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Get(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _entities.SingleOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
