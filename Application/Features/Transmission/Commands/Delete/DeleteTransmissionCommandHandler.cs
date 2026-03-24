using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Transmission.Commands.Delete;

public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionResponse>
{
    private readonly ITransmissionRepository _transmissionRepository;
    private readonly IMapper _mapper;

    public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
    {
        _transmissionRepository = transmissionRepository;
        _mapper = mapper;
    }

    public async Task<DeletedTransmissionResponse> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Transmission? transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
        transmission = _mapper.Map(request, transmission);
        Domain.Entities.Transmission deletedTransmission = await _transmissionRepository.DeleteAsync(transmission);
        DeletedTransmissionResponse response = _mapper.Map<DeletedTransmissionResponse>(deletedTransmission);

        return response;
    }
}
