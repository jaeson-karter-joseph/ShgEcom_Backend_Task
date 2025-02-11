using ErrorOr;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ShgEcom.Application.Common.Constants;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Common.Interfaces.Services;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Commands.Update
{
    public class UpdateProductCommandHandler(IProductRepository _productRepository, IDateTimeProvider dateTimeProvider, IMemoryCache memoryCache) : IRequestHandler<UpdateProductCommand, ErrorOr<ProductResult>>
    {

        public async Task<ErrorOr<ProductResult>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            memoryCache.Remove(CacheConstants.ProductsListKey);
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return Domain.Errors.Errors.Product.ProductNotFound;
            }

            // Update product properties
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;
            product.Tags = request.Tags;
            product.UpdatedAt = dateTimeProvider.UtcNow;

            await _productRepository.UpdateAsync(product);

            return new ProductResult(product);
        }
    }
}
