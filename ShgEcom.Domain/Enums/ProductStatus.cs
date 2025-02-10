using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Domain.Enums
{
    public enum ProductStatus
    {
        /// <summary>
        /// Product is currently in stock and available for purchase
        /// </summary>
        InStock = 1,

        /// <summary>
        /// Product is completely out of stock
        /// </summary>
        OutOfStock = 2,

        /// <summary>
        /// Product is low in stock (less than 10 units)
        /// </summary>
        LowStock = 3,

        /// <summary>
        /// Product is discontinued and no longer available
        /// </summary>
        Discontinued = 4,

        /// <summary>
        /// Product is pending restock
        /// </summary>
        Restocking = 5
    }
}
