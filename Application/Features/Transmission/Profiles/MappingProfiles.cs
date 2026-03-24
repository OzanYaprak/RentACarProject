using Application.Features.Transmission.Commands.Create;
using Application.Features.Transmission.Commands.Delete;
using Application.Features.Transmission.Commands.Update;
using Application.Features.Transmission.Queries.GetById;
using Application.Features.Transmission.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;

namespace Application.Features.Transmission.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Transmission, CreateTransmissionCommand>().ReverseMap();
        CreateMap<Domain.Entities.Transmission, CreatedTransmissionResponse>().ReverseMap();

        CreateMap<Domain.Entities.Transmission, UpdateTransmissionCommand>().ReverseMap();
        CreateMap<Domain.Entities.Transmission, UpdatedTransmissionResponse>().ReverseMap();

        CreateMap<Domain.Entities.Transmission, DeleteTransmissionCommand>().ReverseMap();
        CreateMap<Domain.Entities.Transmission, DeletedTransmissionResponse>().ReverseMap();

        CreateMap<Domain.Entities.Transmission, GetListTransmissionListItemDTO>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.Transmission>, GetListResponse<GetListTransmissionListItemDTO>>().ReverseMap();
        CreateMap<Domain.Entities.Transmission, GetByIdTransmissionResponse>().ReverseMap();
    }
}
