using Application.Features.Transmission.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Transmission.Commands.Create;

public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
{
    private readonly ITransmissionRepository _transmissionRepository;
    private readonly IMapper _mapper;
    private readonly TransmissionBusinessRules _transmissionBusinessRules;

    public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules)
    {
        _transmissionRepository = transmissionRepository;
        _mapper = mapper;
        _transmissionBusinessRules = transmissionBusinessRules;
    }

    public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
    {
        await _transmissionBusinessRules.TransmissionNameCannotBeDuplicatedWhenInserted(request.Name);

        Domain.Entities.Transmission createdTransmission = _mapper.Map<Domain.Entities.Transmission>(request);
        createdTransmission.Id = Guid.NewGuid();

        await _transmissionRepository.AddAsync(createdTransmission);

        CreatedTransmissionResponse createdTransmissionResponse = _mapper.Map<CreatedTransmissionResponse>(createdTransmission);

        return createdTransmissionResponse;
    }
}
