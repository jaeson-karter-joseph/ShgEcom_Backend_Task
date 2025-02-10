using ShgEcom.Domain.Entites.Common;
using ShgEcom.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
