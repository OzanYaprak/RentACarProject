using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;

    public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id, enableTracking: false, withDeleted: true, cancellationToken: cancellationToken);
        GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(brand);
        return response;
    }
}
