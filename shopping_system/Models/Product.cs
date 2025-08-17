namespace shopping.Models;

public class Product
{
    public int Id { get; set; }
    public string PublicIdentifier { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    public string ImageUrl { get; set; } = string.Empty;
    public ProductCategory Category { get; set; } = null!;

    //public int StockQuantity { get; set; } = 0; ?
}
