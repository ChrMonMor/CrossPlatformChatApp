using AutoMapper;
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
        }
    }
}
