using ErrorOr;
using MediatR;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Products.Common;

namespace ShgEcom.Application.Products.Queries.ReadProductByTag
{
    public class GetProductsByTagQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsByTagQuery, ErrorOr<List<ProductResult>>>
    {
        public async Task<ErrorOr<List<ProductResult>>> Handle(GetProductsByTagQuery request, CancellationToken cancellationToken)
        {
            // Fetch the products by tag from the repository
            var products = await productRepository.GetProductsByTagAsync(request.Tag);

            if (products == null || products.Count == 0)
            {
                return Domain.Errors.Errors.Product.ProductNotFoundWithTag; // If no products found with that tag
            }

            // Map entities to results and return
            var productResults = products.Select(p => new ProductResult(p)).ToList();
            return productResults;
        }
    }
}
