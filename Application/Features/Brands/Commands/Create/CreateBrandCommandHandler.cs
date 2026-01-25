using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand createdBrand = _mapper.Map<Brand>(request);
        createdBrand.Id = Guid.NewGuid();

        await _brandRepository.AddAsync(createdBrand);

        CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(createdBrand);

        return createdBrandResponse;
    }
}
