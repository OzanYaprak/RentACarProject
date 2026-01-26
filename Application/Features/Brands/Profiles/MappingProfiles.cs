using AutoMapper;
using Domain.Entities;
using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries.GetList;
using Core.Persistence.Paging;
using Core.Application.Responses;
using Application.Features.Brands.Queries.GetById;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, GetListBrandListItemDTO>().ReverseMap();
        CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDTO>>().ReverseMap();
        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
    }
}
