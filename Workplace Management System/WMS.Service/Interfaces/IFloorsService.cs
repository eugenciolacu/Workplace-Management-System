﻿using WMS.Service.Dtos.Floor;

namespace WMS.Service.Interfaces
{
    public interface IFloorsService
    {
        void DeleteFloor(Guid siteId, Guid id, bool trackChanges);
        IEnumerable<FloorDto> GetFloors(Guid siteId, bool trackChanges);
        public FloorDto GetFloor(Guid siteId, Guid id, bool trackChanges);
        FloorDto CreateFloor(Guid siteId, FloorForCreationDto floor);
    }
}
