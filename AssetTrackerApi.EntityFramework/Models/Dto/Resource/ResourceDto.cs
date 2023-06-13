namespace AssetTrackerApi.EntityFramework.Models.Dto.Resource
{
    public class ResourceDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }
        public double PriceBuy { get; set; }
        public double PriceSell { get; set; }
    }
}
