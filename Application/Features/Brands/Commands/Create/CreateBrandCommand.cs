using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest , ICacheRemoverRequest
{
    public string Name { get; set; } = null!;

    public string CacheKey => throw new NotImplementedException();

    public bool BypassCache => throw new NotImplementedException();
}
