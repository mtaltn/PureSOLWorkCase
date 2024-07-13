using AutoMapper;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Activity, ActivityDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}