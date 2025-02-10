using FluentValidation;

namespace ShgEcom.Application.Products.Queries.ReadProductByTag
{
    public class GetProductsByTagQueryValidator : AbstractValidator<GetProductsByTagQuery>
    {
        public GetProductsByTagQueryValidator()
        {
            RuleFor(x => x.Tag)
                .NotEmpty().WithMessage("Tag is required")   // Ensure tag is not empty or null
                .MaximumLength(100).WithMessage("Tag cannot be longer than 100 characters"); // Optional: max length for tag
        }
    }
}
