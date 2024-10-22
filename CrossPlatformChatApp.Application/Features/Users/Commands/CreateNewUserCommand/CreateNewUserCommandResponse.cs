﻿using CrossPlatformChatApp.Application.Responses;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserCommandResponse : BaseResponse {
        public CreateNewUserCommandVm NewUser { get; set; }
        public CreateNewUserCommandResponse() : base() { }
    }
}