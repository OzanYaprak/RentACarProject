using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
{
    public Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        CreatedBrandResponse createdBrandResponse  = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        return Task.FromResult(createdBrandResponse);
    }
}
