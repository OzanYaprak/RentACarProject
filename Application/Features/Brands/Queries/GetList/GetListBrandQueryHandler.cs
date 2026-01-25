using MediatR;
using Core.Application.Responses;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDTO>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListBrandListItemDTO>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
    {
        Paginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

        GetListResponse<GetListBrandListItemDTO> response = _mapper.Map<GetListResponse<GetListBrandListItemDTO>>(brands);
        return response;
    }
}
