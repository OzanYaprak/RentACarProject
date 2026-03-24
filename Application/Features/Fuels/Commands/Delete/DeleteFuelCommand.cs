using MediatR;

namespace Application.Features.Fuels.Commands.Delete;

public class DeleteFuelCommand : IRequest<DeletedFuelResponse>
{
    public Guid Id { get; set; }
}
