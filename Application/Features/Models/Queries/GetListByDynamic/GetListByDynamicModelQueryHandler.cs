using Application.Features.Models.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Models.Queries.GetListByDynamic;

public class GetListByDynamicModelQueryHandler : IRequestHandler<GetListByDynamicModelQuery, GetListResponse<GetListByDynamicModelListItemDTO>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByDynamicModelListItemDTO>> Handle(GetListByDynamicModelQuery request, CancellationToken cancellationToken)
    {
        Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
            dynamic: request.DynamicQuery,
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            include: m => m.Include(x => x.Brand).Include(f => f.Fuel).Include(t => t.Transmission),
            cancellationToken: cancellationToken);

        GetListResponse<GetListByDynamicModelListItemDTO> response = _mapper.Map<GetListResponse<GetListByDynamicModelListItemDTO>>(models);
        return response;
    }
}
