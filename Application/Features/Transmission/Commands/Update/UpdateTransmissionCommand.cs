using MediatR;

namespace Application.Features.Transmission.Commands.Update;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
