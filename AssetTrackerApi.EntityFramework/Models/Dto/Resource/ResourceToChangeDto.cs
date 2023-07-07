using AssetTrackerApi.EntityFramework.Models.Dto.Balance;

namespace AssetTrackerApi.EntityFramework.Models.Dto.Resource
{
    public class ResourceToChangeDto
    {
        public int ResourceId { get; set; }
        public int Quantity { get; set; }
        public OperationType OperationType { get; set; }
    }
}
