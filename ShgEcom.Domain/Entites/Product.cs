using ShgEcom.Domain.Entites.Common;
using ShgEcom.Domain.Enums;

namespace ShgEcom.Domain.Entites
{
    public record Product : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public ProductStatus Status { get; private set; }
        public List<string> Tags { get; private set; } = [];
    }
}
