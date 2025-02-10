using ShgEcom.Domain.Entites.Common;
using ShgEcom.Domain.Enums;

namespace ShgEcom.Domain.Entites
{
    public record Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; }
        public List<string> Tags { get; set; } = [];
    }
}
