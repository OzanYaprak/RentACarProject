using Application.Features.Fuels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Fuels.Rules;

public class FuelBusinessRules : BaseBusinessRules
{
    private readonly IFuelRepository _fuelRepository;

    public FuelBusinessRules(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }

    public async Task FuelNameCannotBeDuplicatedWhenInserted(string name)
    {
        Fuel? fuel = await _fuelRepository.GetAsync(predicate: f => f.Name.ToLower() == name.ToLower());

        if (fuel != null)
        {
            throw new BusinessException(FuelMessages.FuelNameExists);
        }
    }
}
