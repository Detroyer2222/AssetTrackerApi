namespace AssetTrackerApi.EntityFramework.Models.Dto.Resource
{
    public class OrganizationResourceDto
    {
        public string ResourceName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalValue { get; set; }
    }
}
