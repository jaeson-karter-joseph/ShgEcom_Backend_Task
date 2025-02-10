using MongoDB.Bson.Serialization.Attributes;
using ShgEcom.Domain.Entites.Common;
using ShgEcom.Domain.Enums;

namespace ShgEcom.Domain.Entites
{
    public record Product : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("description")]
        public string Description { get; set; } = null!;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("stock_quantity")]
        public int StockQuantity { get; set; }

        [BsonElement("status")]
        public ProductStatus Status { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; } = [];
    }
}
