using Application.Features.Transmission.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Transmission.Rules;

public class TransmissionBusinessRules : BaseBusinessRules
{
    private readonly ITransmissionRepository _transmissionRepository;

    public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
    {
        _transmissionRepository = transmissionRepository;
    }

    public async Task TransmissionNameCannotBeDuplicatedWhenInserted(string name)
    {
        Domain.Entities.Transmission? transmission = await _transmissionRepository.GetAsync(predicate: t => t.Name.ToLower() == name.ToLower());

        if (transmission != null)
        {
            throw new BusinessException(TransmissionMessages.TransmissionNameExists);
        }
    }
}
