using WMS.Data.Entities;

namespace WMS.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    { // to be deleted
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
