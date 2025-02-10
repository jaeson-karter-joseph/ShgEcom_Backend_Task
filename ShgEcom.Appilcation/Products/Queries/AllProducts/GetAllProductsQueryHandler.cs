using ErrorOr;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ShgEcom.Application.Common.Constants;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Products.Common;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Products.Queries.AllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository, IMemoryCache memoryCache) : IRequestHandler<GetAllProductsQuery, ErrorOr<List<ProductResult>>>
    {
        public async Task<ErrorOr<List<ProductResult>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            if (!memoryCache.TryGetValue(CacheConstants.ProductsListKey, out List<Product>? products))
            {
                products = await productRepository.GetAllAsync();
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = CacheConstants.CacheDuration
                };
                memoryCache.Set(CacheConstants.ProductsListKey, products, cacheOptions);
            }
            if (products == null || products.Count == 0)
            {
                return Domain.Errors.Errors.Product.NoProductsFound;
            }

            return products.Select(product => new ProductResult(product)).ToList();
        }
    }
}
