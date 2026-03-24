using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Delete;

public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeletedFuelResponse>
{
    private readonly IFuelRepository _fuelRepository;
    private readonly IMapper _mapper;

    public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
    {
        _fuelRepository = fuelRepository;
        _mapper = mapper;
    }

    public async Task<DeletedFuelResponse> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
    {
        Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
        fuel = _mapper.Map(request, fuel);
        Fuel deletedFuel = await _fuelRepository.DeleteAsync(fuel);
        DeletedFuelResponse response = _mapper.Map<DeletedFuelResponse>(deletedFuel);

        return response;
    }
}
