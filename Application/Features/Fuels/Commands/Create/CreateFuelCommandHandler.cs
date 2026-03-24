using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Create;

public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreatedFuelResponse>
{
    private readonly IFuelRepository _fuelRepository;
    private readonly IMapper _mapper;
    private readonly FuelBusinessRules _fuelBusinessRules;

    public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
    {
        _fuelRepository = fuelRepository;
        _mapper = mapper;
        _fuelBusinessRules = fuelBusinessRules;
    }

    public async Task<CreatedFuelResponse> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
    {
        await _fuelBusinessRules.FuelNameCannotBeDuplicatedWhenInserted(request.Name);

        Fuel createdFuel = _mapper.Map<Fuel>(request);
        createdFuel.Id = Guid.NewGuid();

        await _fuelRepository.AddAsync(createdFuel);

        CreatedFuelResponse createdFuelResponse = _mapper.Map<CreatedFuelResponse>(createdFuel);

        return createdFuelResponse;
    }
}
