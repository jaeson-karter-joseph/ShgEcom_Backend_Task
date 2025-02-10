using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShgEcom.Contracts.Products
{
    public record CreateProductRequest
    {
        [Required]
        [JsonPropertyName("name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
        [DefaultValue("Sample Product")]
        [SwaggerSchema(Description = "Product name")]
        public string Name { get; set; } = "Sample Product";

        [JsonPropertyName("description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [DefaultValue("Product description")]
        [SwaggerSchema(Description = "Product detailed description")]
        public string Description { get; set; } = "Standard product description";

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        [JsonPropertyName("price")]
        [DefaultValue(9.99)]
        [SwaggerSchema(Description = "Product price")]
        public decimal Price { get; set; } = 9.99m;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        [JsonPropertyName("stockQuantity")]
        [DefaultValue(100)]
        [SwaggerSchema(Description = "Available stock quantity")]
        public int StockQuantity { get; set; } = 100;

        [JsonPropertyName("tags")]
        [DefaultValue(new[] { "default" })]
        [SwaggerSchema(Description = "Product tags")]
        public List<string> Tags { get; set; } = null!;
    }
}
