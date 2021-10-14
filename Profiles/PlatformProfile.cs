using AutoMapper;

namespace PlatformSerivce.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<PlatformService.Models.Platform, PlatformService.DTOs.PlatformReadDto>();
            CreateMap<PlatformService.DTOs.PlatformCreateDto, PlatformService.Models.Platform>();
        }
    }
}