using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Fuels.Queries.GetList;

public class GetListFuelQuery : IRequest<GetListResponse<GetListFuelListItemDTO>>, ICacheableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey { get { return $"fuels_list_{PageRequest.PageIndex}_{PageRequest.PageSize}"; } }
    public bool BypassCache { get; }
    public int SlidingExpirationTime { get; }
}
