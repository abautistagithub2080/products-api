namespace PRODUCTS_API.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? StatusName { get; set; }
        public string? Stock { get; set; }
        public string? Description { get; set; }        
        public string? Price { get; set; }
        public string? Discount { get; set; }
        public string? FinalPrice { get; set; }
    }
}
