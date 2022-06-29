using WMS.Data.Entities.Core;

namespace WMS.Repository.Extensions
{
    public static class FloorRepositoryExtensions
    {
        public static IQueryable<Floor> FilterFloors(this IQueryable<Floor> floors, uint minCapacity, uint maxCapacity) =>
            floors.Where(f => (f.Capacity >= minCapacity && f.Capacity <= maxCapacity));

        public static IQueryable<Floor> Search(this IQueryable<Floor> floors, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return floors;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return floors.Where(f => f.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
