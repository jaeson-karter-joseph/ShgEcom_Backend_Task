using ErrorOr;
using MediatR;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Products.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Application.Products.Queries.AllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, ErrorOr<List<ProductResult>>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ErrorOr<List<ProductResult>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            if (products == null || products.Count == 0)
            {
                return Domain.Errors.Errors.Product.NoProductsFound;
            }

            return products.Select(product => new ProductResult(product)).ToList();
        }
    }
}
