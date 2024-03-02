namespace ProductManagementService.DTOs.ProductDTOs
{
    public class ProductRequestDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }
        public int GroupId { get; set; }
    }
}
