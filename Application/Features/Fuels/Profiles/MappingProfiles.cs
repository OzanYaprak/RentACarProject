using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Fuels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
        CreateMap<Fuel, CreatedFuelResponse>().ReverseMap();

        CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
        CreateMap<Fuel, UpdatedFuelResponse>().ReverseMap();

        CreateMap<Fuel, DeleteFuelCommand>().ReverseMap();
        CreateMap<Fuel, DeletedFuelResponse>().ReverseMap();

        CreateMap<Fuel, GetListFuelListItemDTO>().ReverseMap();
        CreateMap<Paginate<Fuel>, GetListResponse<GetListFuelListItemDTO>>().ReverseMap();
        CreateMap<Fuel, GetByIdFuelResponse>().ReverseMap();
    }
}
