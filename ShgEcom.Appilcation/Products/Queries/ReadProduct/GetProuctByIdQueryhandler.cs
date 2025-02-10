using ErrorOr;
using MediatR;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Products.Common;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Products.Queries.ReadProduct
{
    public class GetProuctByIdQueryhandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResult>>
    {
        public async Task<ErrorOr<ProductResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (await productRepository.GetByIdAsync(request.ProductId) is not Product product)
            {
                return Domain.Errors.Errors.Product.ProductNotFound;
            }

            return new ProductResult(product);
        }
    }
}
