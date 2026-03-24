using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Fuels.Commands.Create;

public class CreateFuelCommand : IRequest<CreatedFuelResponse>, ITransactionalRequest
{
    public string Name { get; set; } = null!;
}
