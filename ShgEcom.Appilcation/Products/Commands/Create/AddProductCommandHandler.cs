using ErrorOr;
using MediatR;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Products.Commands.Common;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Products.Commands.Create
{
    public class AddProductCommandHandler(IProductRepository productRepository) : IRequestHandler<AddProductCommand, ErrorOr<ProductResult>>
    {
        public async Task<ErrorOr<ProductResult>> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = command.Description,
                IsDeleted = false,
                Name = command.Name,
                Price = command.Price,
                Status = (Domain.Enums.ProductStatus)command.ProductStatus,
                StockQuantity = command.StockQuantity,
                Tags = command.Tags
            };

            await productRepository.AddAsync(product);

            return new ProductResult(product);
        }
    }
}
