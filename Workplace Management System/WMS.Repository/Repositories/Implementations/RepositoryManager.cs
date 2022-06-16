using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {
        private CoreDbContext _coreDbContext;

        private ISiteRepository _siteRepository = null!;
        private IFloorRepository _floorRepository = null!;
        private IWorkplaceRepository _workplaceRepository = null!;
        private IEmployeeRepository _employeeRepository = null!;
        private IReservationRepository _reservationRepository = null!;

        public RepositoryManager(CoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        public ISiteRepository Site
        {
            get
            {
                if (_siteRepository == null)
                {
                    _siteRepository = new SiteRepository(_coreDbContext);
                }

                return _siteRepository;
            }
        }

        public IFloorRepository Floor
        {
            get
            {
                if (_floorRepository == null)
                {
                    _floorRepository = new FloorRepository(_coreDbContext);
                }

                return _floorRepository;
            }
        }

        public IWorkplaceRepository Workplace
        {
            get
            {
                if (_workplaceRepository == null)
                {
                    _workplaceRepository = new WorkplaceRepository(_coreDbContext);
                }

                return _workplaceRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_coreDbContext);
                }

                return _employeeRepository;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (_reservationRepository == null)
                {
                    _reservationRepository = new ReservationRepository(_coreDbContext);
                }

                return _reservationRepository;
            }
        }

        public void Save() => _coreDbContext.SaveChanges();
    }
}
