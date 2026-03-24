using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Transmission.Commands.Update;

public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionResponse>
{
    private readonly ITransmissionRepository _transmissionRepository;
    private readonly IMapper _mapper;

    public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
    {
        _transmissionRepository = transmissionRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedTransmissionResponse> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Transmission? transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
        transmission = _mapper.Map(request, transmission);
        Domain.Entities.Transmission updatedTransmission = await _transmissionRepository.UpdateAsync(transmission);
        UpdatedTransmissionResponse response = _mapper.Map<UpdatedTransmissionResponse>(updatedTransmission);
        return response;
    }
}
