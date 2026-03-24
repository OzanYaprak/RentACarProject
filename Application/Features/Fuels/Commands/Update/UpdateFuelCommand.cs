using MediatR;

namespace Application.Features.Fuels.Commands.Update;

public class UpdateFuelCommand : IRequest<UpdatedFuelResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
