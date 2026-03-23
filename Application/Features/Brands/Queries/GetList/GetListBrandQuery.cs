using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDTO>>, ICacheableRequest
{
    public PageRequest PageRequest { get; set; }


    public string CacheKey { get { return $"brands_list_{PageRequest.PageIndex}_{PageRequest.PageSize}"; } }
    public bool BypassCache { get; }
    public int SlidingExpirationTime { get; }
}
