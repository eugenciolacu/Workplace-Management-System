namespace WMS.Repository.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        ISiteRepository Site { get; }
        IFloorRepository Floor { get; }
        IWorkplaceRepository Workplace { get; }
        IEmployeeRepository Employee { get; }
        IReservationRepository Reservation { get; }
        Task SaveAsync();
    }
}
