using FluentValidation;

namespace Application.Features.Transmission.Commands.Create;

public class CreateTransmissionCommandValidator : AbstractValidator<CreateTransmissionCommand>
{
    public CreateTransmissionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Vites tipi adı gereklidir.")
            .MinimumLength(2).WithMessage("Vites tipi adı en az 2 karakter uzunluğunda olmalıdır.")
            .MaximumLength(50).WithMessage("Vites tipi adı 50 karakteri aşmamalıdır.");
    }
}
