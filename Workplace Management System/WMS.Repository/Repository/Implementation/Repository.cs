using Microsoft.EntityFrameworkCore;
using WMS.Data.Entity;
using WMS.Repository.Context;

namespace WMS.Repository.Repository.Implementation
{
    public class Repository<T> : Interface.IRepository<T> where T : BaseEntity
    {
        private readonly CoreDbContext _context;
        private DbSet<T> _entities;
        string errorMessage = String.Empty;

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
