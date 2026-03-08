using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest
{
    public string Name { get; set; } = null!;
}
