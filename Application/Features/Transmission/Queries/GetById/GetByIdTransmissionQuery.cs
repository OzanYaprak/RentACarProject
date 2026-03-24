using MediatR;

namespace Application.Features.Transmission.Queries.GetById;

public class GetByIdTransmissionQuery : IRequest<GetByIdTransmissionResponse>
{
    public Guid Id { get; set; }
}
