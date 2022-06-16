using WMS.Data.Entities.Core;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(CoreDbContext coreDbContext) : base(coreDbContext)
        {

        }
    }
}
