using ErrorOr;
using MediatR;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Common.Interfaces.Services;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Commands.Update
{
    public class UpdateProductCommandHandler(IProductRepository productRepository, IDateTimeProvider dateTimeProvider) : IRequestHandler<UpdateProductCommand, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ErrorOr<ProductResult>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
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
