using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FriendsBook.Core.Domain;
using FriendsBook.Infrastructure.DTO;

namespace FriendsBook.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Board, BoardDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            })
            .CreateMapper();
    }
}
