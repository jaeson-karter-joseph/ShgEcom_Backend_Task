using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShgEcom.Application.Products.Commands.Common;
using ShgEcom.Application.Products.Commands.Create;
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
    }
}
