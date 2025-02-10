﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Application.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product Id is required") // Ensure the Guid is not empty
                .Must(id => id != Guid.Empty).WithMessage("Product Id cannot be an empty GUID");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero")
                .PrecisionScale(18, 2, false).WithMessage("Price cannot exceed 18 digits with 2 decimal places");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative")
                .LessThanOrEqualTo(10000).WithMessage("Stock quantity cannot exceed 10000");

            RuleFor(x => x.Tags)
               .Must(list => list.Count <= 10).WithMessage("Maximum 10 tags allowed")
               .Must(list => list.All(tag => tag.Length <= 50)).WithMessage("Each tag must be 50 characters or less");
        }
    }

}
