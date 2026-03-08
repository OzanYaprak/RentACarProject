using FluentValidation;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Marka adı gereklidir.")
            .MinimumLength(2).WithMessage("Marka adı en az 2 karakter uzunluğunda olmalıdır.")
            .MaximumLength(50).WithMessage("Marka adı 50 karakteri aşmamalıdır.");
    }
}
    