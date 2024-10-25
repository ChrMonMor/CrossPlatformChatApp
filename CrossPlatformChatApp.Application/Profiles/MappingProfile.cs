using AutoMapper;
using CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand;
using CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin;
using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Profiles {
    public class MappingProfile : Profile{
        public MappingProfile() { 
            CreateMap<User, UserByLoginVm>().ReverseMap();
            CreateMap<User, CreateNewUserCommand>().ReverseMap();
            CreateMap<User, CreateNewUserCommandVm>().ReverseMap();
            CreateMap<Message, SendMessageCommand>().ReverseMap();
            CreateMap<Message, SendMessageCommandVm>().ReverseMap();
        }
    }
}
