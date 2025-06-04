using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuradayimBackend.Dtos.Post;
using BuradayimBackend.Dtos.User;
using BuradayimBackend.Models;

namespace BuradayimBackend.Utilities
{
public class MappingProfile : Profile
{
    public MappingProfile()
        {
            // User -> UserDto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src =>
                    src.ProfilePicture != null ? Convert.ToBase64String(src.ProfilePicture) : null));

            // RegisterDto -> User
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));

            // Post -> PostDto
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src =>
                    src.Images.Select(img => Convert.ToBase64String(img)).ToList()));

            // CreatePostDto -> Post
            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src =>
                    src.Images.Select(base64 => Convert.FromBase64String(base64)).ToList()));
        }
}

}