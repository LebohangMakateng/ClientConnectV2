using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Gig, GigDto>();
            CreateMap<RegisterDto, IdentityUser>();
            CreateMap<GigUpdateDto, Gig>();
        }
    }
}