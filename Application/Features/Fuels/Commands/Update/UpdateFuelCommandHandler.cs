using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Update;

public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelResponse>
{
    private readonly IFuelRepository _fuelRepository;
    private readonly IMapper _mapper;

    public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
    {
        _fuelRepository = fuelRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedFuelResponse> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
    {
        Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
        fuel = _mapper.Map(request, fuel);
        Fuel updatedFuel = await _fuelRepository.UpdateAsync(fuel);
        UpdatedFuelResponse response = _mapper.Map<UpdatedFuelResponse>(updatedFuel);
        return response;
    }
}
