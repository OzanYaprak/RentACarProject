using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Transmission.Commands.Create;

public class CreateTransmissionCommand : IRequest<CreatedTransmissionResponse>, ITransactionalRequest
{
    public string Name { get; set; } = null!;
}
