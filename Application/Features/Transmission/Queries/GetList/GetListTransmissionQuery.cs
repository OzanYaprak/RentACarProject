using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Transmission.Queries.GetList;

public class GetListTransmissionQuery : IRequest<GetListResponse<GetListTransmissionListItemDTO>>, ICacheableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey { get { return $"transmissions_list_{PageRequest.PageIndex}_{PageRequest.PageSize}"; } }
    public bool BypassCache { get; }
    public int SlidingExpirationTime { get; }
}
