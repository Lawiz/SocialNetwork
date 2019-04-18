using  AutoMapper;
using BLL.Domain.Models;
using Habr.Dtos;

namespace Habr.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
