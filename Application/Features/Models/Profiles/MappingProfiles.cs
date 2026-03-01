using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelListItemDTO>()
            .ForMember(destinationMember: x => x.BrandName, memberOptions: opt => opt.MapFrom(x => x.Brand.Name))
            .ForMember(destinationMember: x => x.FuelName, memberOptions: opt => opt.MapFrom(x => x.Fuel.Name))
            .ForMember(destinationMember: x => x.TransmissionName, memberOptions: opt => opt.MapFrom(x => x.Transmission.Name))
            .ReverseMap();

        CreateMap<Model, GetListByDynamicModelListItemDTO>()
            .ForMember(destinationMember: x => x.BrandName, memberOptions: opt => opt.MapFrom(x => x.Brand.Name))
            .ForMember(destinationMember: x => x.FuelName, memberOptions: opt => opt.MapFrom(x => x.Fuel.Name))
            .ForMember(destinationMember: x => x.TransmissionName, memberOptions: opt => opt.MapFrom(x => x.Transmission.Name))
            .ReverseMap();

        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDTO>>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDTO>>().ReverseMap();
    }
}
