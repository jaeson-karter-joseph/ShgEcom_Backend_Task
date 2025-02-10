using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShgEcom.Application.Products.Commands.Create;
using ShgEcom.Application.Products.Commands.Delete;
using ShgEcom.Application.Products.Commands.Update;
using ShgEcom.Application.Products.Common;
using ShgEcom.Application.Products.Queries.AllProducts;
using ShgEcom.Application.Products.Queries.ReadProduct;
using ShgEcom.Application.Products.Queries.ReadProductByTag;
using ShgEcom.Contracts.Products;

namespace ShgEcom.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ProductController(ISender mediator, IMapper _mapper) : ApiController
    {
        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var command = _mapper.Map<AddProductCommand>(request);
            ErrorOr<ProductResult> result = await mediator.Send(command);
            return result.Match(result => Ok(_mapper.Map<ProductResult>(result)), Problem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = _mapper.Map<GetProductByIdQuery>(id);
            ErrorOr<ProductResult> result = await mediator.Send(query);
            return result.Match(result => Ok(_mapper.Map<ProductResult>(result)), Problem);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await mediator.Send(new GetAllProductsQuery());
            return result.Match(result => Ok(_mapper.Map<List<ProductResult>>(result)), Problem);
        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {
            var command = _mapper.Map<UpdateProductCommand>(request);
            var result = await mediator.Send(command);
            return result.Match(result => Ok(_mapper.Map<ProductResult>(result)), Problem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = _mapper.Map<DeleteProductCommand>(id);
            var result = await mediator.Send(command);
            return result.Match(_ => Ok(new { Message = $"Product deleted successfully with ID {id}!" }), Problem);
        }

        [HttpPost("getAllBytags")]
        public async Task<IActionResult> GetProductsByTag(GetProductByTag tag)
        {
            var query = _mapper.Map<GetProductsByTagQuery>(tag);
            var result = await mediator.Send(query);
            return result.Match(Ok, Problem);
        }
    }
}
