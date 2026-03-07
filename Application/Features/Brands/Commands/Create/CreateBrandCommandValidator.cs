using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator: AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name is required.");
    }
}
