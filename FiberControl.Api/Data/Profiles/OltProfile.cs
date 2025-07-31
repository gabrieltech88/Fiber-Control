using FiberControlApi.Data.Dtos.requests;
using  FiberControlApi.Data.Models;
using AutoMapper;

namespace FiberControlApi.Profiles;

public class OltProfile : Profile 
{
    public OltProfile()
    {
        CreateMap<CreateOltRequest, Olt>();
    }
}