using MediatR;

namespace Application.Features.Fuels.Queries.GetById;

public class GetByIdFuelQuery : IRequest<GetByIdFuelResponse>
{
    public Guid Id { get; set; }
}
