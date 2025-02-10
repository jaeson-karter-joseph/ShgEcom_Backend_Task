using Mapster;
using ShgEcom.Application.Products.Commands.Create;
using ShgEcom.Application.Products.Commands.Update;
using ShgEcom.Application.Products.Queries.ReadProduct;
using ShgEcom.Contracts.Products;

namespace ShgEcom.Api.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductRequest, AddProductCommand>();
            config.NewConfig<UpdateProductRequest, UpdateProductCommand>();
            config.NewConfig<Guid, GetProductByIdQuery>().Map(dest => dest.ProductId, src => src);
        }
    }
}
