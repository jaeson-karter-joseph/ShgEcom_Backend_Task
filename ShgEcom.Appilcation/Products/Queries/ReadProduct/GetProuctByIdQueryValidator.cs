using FluentValidation;

namespace ShgEcom.Application.Products.Queries.ReadProduct
{
    public class GetProuctByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProuctByIdQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid Product ID format.");
        }
    }
}
