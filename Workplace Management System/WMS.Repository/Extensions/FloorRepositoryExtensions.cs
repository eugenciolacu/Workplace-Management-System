using System.Linq.Dynamic.Core;
using WMS.Data.Entities.Core;
using WMS.Repository.Extensions.Utility;

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

        public static IQueryable<Floor> Sort(this IQueryable<Floor> floors, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return floors.OrderBy(f => f.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Floor>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return floors.OrderBy(f => f.Name);

            return floors.OrderBy(orderQuery);
        }
    }
}
