using WMS.Data.Entities.Core;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CoreDbContext coreDbContext) : base(coreDbContext)
        {

        }
    }
}
