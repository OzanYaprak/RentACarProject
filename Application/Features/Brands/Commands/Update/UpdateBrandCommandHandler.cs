using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);
        brand = _mapper.Map(request, brand);
        Brand updatedBrand = await _brandRepository.UpdateAsync(brand);
        UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(updatedBrand);
        return response;
    }
}
