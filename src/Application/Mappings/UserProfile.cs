using AutoMapper;
using Domain.Entities;
using Application.UseCases.Users.ManageUser;
using Application.UseCases.Users.SearchUser;
using Application.UseCases.Users.RegisterUser;
using Application.Models;
using Application.UseCases.Users.LoginUser;

namespace Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoginUserInput>().ReverseMap();
            CreateMap<User, LoginUserOutput>().ReverseMap();
            CreateMap<User, ManageUserInput>().ReverseMap();
            CreateMap<User, ManageUserOutput>().ReverseMap();
            CreateMap<User, SearchUserOutput>().ReverseMap();
            CreateMap<User, RegisterUserInput>().ReverseMap();
            CreateMap<User, RegisterUserOutput>().ReverseMap();
            CreateMap<User, UserAuth>().ReverseMap();
        }
    }
}
