using ErrorOr;
using MediatR;
using ShgEcom.Application.Common.Interfaces.Persistence;

namespace ShgEcom.Application.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, ErrorOr<bool>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ErrorOr<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
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
