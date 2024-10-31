using AutoMapper;
using CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand;
using CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand;
using CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin;
using CrossPlatformChatApp.Domain.Models;

namespace CrossPlatformChatApp.Application.Profiles {
    public class MappingProfile : Profile{
        public MappingProfile() { 
            //User Mapping
            CreateMap<User, UserByIdVm>().ReverseMap();
            CreateMap<User, UserByLoginVm>().ReverseMap();
            CreateMap<User, CreateNewUserCommandVm>().ReverseMap();
            //Message Mapping
            CreateMap<Message, SendMessageCommandVm>().ReverseMap();
            //Chat Mapping
            CreateMap<Chat, CreateNewChatCommandVm>().ReverseMap();
        }
    }
}
