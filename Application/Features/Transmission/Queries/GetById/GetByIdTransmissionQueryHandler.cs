using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Transmission.Queries.GetById;

public class GetByIdTransmissionQueryHandler : IRequestHandler<GetByIdTransmissionQuery, GetByIdTransmissionResponse>
{
    private readonly IMapper _mapper;
    private readonly ITransmissionRepository _transmissionRepository;

    public GetByIdTransmissionQueryHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
    {
        _mapper = mapper;
        _transmissionRepository = transmissionRepository;
    }

    public async Task<GetByIdTransmissionResponse> Handle(GetByIdTransmissionQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Transmission? transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id, enableTracking: false, withDeleted: true, cancellationToken: cancellationToken);
        GetByIdTransmissionResponse response = _mapper.Map<GetByIdTransmissionResponse>(transmission);
        return response;
    }
}
