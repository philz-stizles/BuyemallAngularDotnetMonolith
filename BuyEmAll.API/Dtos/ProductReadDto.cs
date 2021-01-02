namespace BuyEmAll.API.Dtos
{
    public class ProductReadDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}