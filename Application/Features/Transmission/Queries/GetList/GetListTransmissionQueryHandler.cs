using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Transmission.Queries.GetList;

public class GetListTransmissionQueryHandler : IRequestHandler<GetListTransmissionQuery, GetListResponse<GetListTransmissionListItemDTO>>
{
    private readonly ITransmissionRepository _transmissionRepository;
    private readonly IMapper _mapper;

    public GetListTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
    {
        _transmissionRepository = transmissionRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListTransmissionListItemDTO>> Handle(GetListTransmissionQuery request, CancellationToken cancellationToken)
    {
        Paginate<Domain.Entities.Transmission> transmissions = await _transmissionRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

        GetListResponse<GetListTransmissionListItemDTO> response = _mapper.Map<GetListResponse<GetListTransmissionListItemDTO>>(transmissions);
        return response;
    }
}
