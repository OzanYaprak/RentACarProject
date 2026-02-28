using Application.Features.Brands.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDTO>>
{
    public PageRequest? PageRequest { get; set; }
}

public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDTO>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListModelListItemDTO>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        Paginate<Model> models = await _modelRepository.GetListAsync(
            index: request.PageRequest.PageIndex, 
            size: request.PageRequest.PageSize,
            include: m => m.Include(x => x.Brand).Include(f=>f.Fuel).Include(t=>t.Transmission),
            cancellationToken: cancellationToken);

        GetListResponse<GetListModelListItemDTO> response = _mapper.Map<GetListResponse<GetListModelListItemDTO>>(models);
        return response;
    }
}