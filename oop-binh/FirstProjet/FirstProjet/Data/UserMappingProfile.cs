using AutoMapper;
using FirstProjet.DTOs.Request;
using FirstProjet.DTOs.Response;
using FirstProjet.Models;

namespace FirstProjet.Data
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserCreateRequest, User>();
        }
    }
}
