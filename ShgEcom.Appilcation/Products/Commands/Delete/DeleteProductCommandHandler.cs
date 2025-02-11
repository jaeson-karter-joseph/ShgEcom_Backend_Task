using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using ShgEcom.Application.Common.Constants;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.SignalR;

namespace ShgEcom.Application.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, IMemoryCache memoryCache, IHubContext<NotificationHub> notificationHubContext) : IRequestHandler<DeleteProductCommand, ErrorOr<bool>>
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
            await notificationHubContext.Clients.All.SendAsync("ProductDeleted", $"❌ Product deleted: {product.Name}", cancellationToken: cancellationToken);
            return true; // Return true if deletion is successful
        }
    }
}
