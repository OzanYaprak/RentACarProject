using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetList;

public class GetListFuelQueryHandler : IRequestHandler<GetListFuelQuery, GetListResponse<GetListFuelListItemDTO>>
{
    private readonly IFuelRepository _fuelRepository;
    private readonly IMapper _mapper;

    public GetListFuelQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
    {
        _fuelRepository = fuelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListFuelListItemDTO>> Handle(GetListFuelQuery request, CancellationToken cancellationToken)
    {
        Paginate<Fuel> fuels = await _fuelRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

        GetListResponse<GetListFuelListItemDTO> response = _mapper.Map<GetListResponse<GetListFuelListItemDTO>>(fuels);
        return response;
    }
}
