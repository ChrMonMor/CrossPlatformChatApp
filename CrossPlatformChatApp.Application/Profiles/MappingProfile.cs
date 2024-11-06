using AutoMapper;
using CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand;
using CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats;
using CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById;
using CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand;
using CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetAllUsers;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin;
using CrossPlatformChatApp.Domain.Models;

namespace CrossPlatformChatApp.Application.Profiles {
    public class MappingProfile : Profile{
        public MappingProfile() { 
            //User Mapping
            CreateMap<User, UserByIdVm>().ReverseMap();
            CreateMap<User, UserByLoginVm>().ReverseMap();
            CreateMap<User, UserByLoginBaseVm>().ReverseMap();
            CreateMap<User, UserByLoginAddOnFriendVm>().ReverseMap();
            CreateMap<User, CreateNewUserCommandVm>().ReverseMap();
            CreateMap<User, GetChatByIdAddOnUser>().ReverseMap();
            CreateMap<User, GetAllUsersVm>().ReverseMap();
            //Message Mapping
            CreateMap<Message, SendMessageCommandVm>().ReverseMap();
            //Chat Mapping
            CreateMap<Chat, CreateNewChatCommandVm>().ReverseMap();
            CreateMap<Chat, UserByLoginAddOnChatVm>().ReverseMap();
            CreateMap<Chat, GetAllChatsVm>().ReverseMap();
            CreateMap<Chat, GetChatByIdBase>().ReverseMap();

        }
    }
}
