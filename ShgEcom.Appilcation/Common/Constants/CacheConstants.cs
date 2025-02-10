using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Application.Common.Constants
{
    public static class CacheConstants
    {
        public static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(10);
        public const string ProductsListKey = "products_list";
    }
}
