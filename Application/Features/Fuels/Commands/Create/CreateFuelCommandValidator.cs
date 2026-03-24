using FluentValidation;

namespace Application.Features.Fuels.Commands.Create;

public class CreateFuelCommandValidator : AbstractValidator<CreateFuelCommand>
{
    public CreateFuelCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Yakıt tipi adı gereklidir.")
            .MinimumLength(2).WithMessage("Yakıt tipi adı en az 2 karakter uzunluğunda olmalıdır.")
            .MaximumLength(50).WithMessage("Yakıt tipi adı 50 karakteri aşmamalıdır.");
    }
}
