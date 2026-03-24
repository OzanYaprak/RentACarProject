using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetById;

public class GetByIdFuelQueryHandler : IRequestHandler<GetByIdFuelQuery, GetByIdFuelResponse>
{
    private readonly IMapper _mapper;
    private readonly IFuelRepository _fuelRepository;

    public GetByIdFuelQueryHandler(IMapper mapper, IFuelRepository fuelRepository)
    {
        _mapper = mapper;
        _fuelRepository = fuelRepository;
    }

    public async Task<GetByIdFuelResponse> Handle(GetByIdFuelQuery request, CancellationToken cancellationToken)
    {
        Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id, enableTracking: false, withDeleted: true, cancellationToken: cancellationToken);
        GetByIdFuelResponse response = _mapper.Map<GetByIdFuelResponse>(fuel);
        return response;
    }
}
