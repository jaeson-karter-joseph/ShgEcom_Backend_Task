using ErrorOr;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ShgEcom.Application.Common.Constants;
using ShgEcom.Application.Common.Interfaces.Persistence;

namespace ShgEcom.Application.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, IMemoryCache memoryCache) : IRequestHandler<DeleteProductCommand, ErrorOr<bool>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ErrorOr<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            memoryCache.Remove(CacheConstants.ProductsListKey);
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return Domain.Errors.Errors.Product.ProductNotFound;
            }

            // Attempt to delete the product
            await _productRepository.SoftDeleteAsync(request.Id);

            return true; // Return true if deletion is successful
        }
    }
}
