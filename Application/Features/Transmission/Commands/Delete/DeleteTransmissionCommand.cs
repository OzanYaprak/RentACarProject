using MediatR;

namespace Application.Features.Transmission.Commands.Delete;

public class DeleteTransmissionCommand : IRequest<DeletedTransmissionResponse>
{
    public Guid Id { get; set; }
}
