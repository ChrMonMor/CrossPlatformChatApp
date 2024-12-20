﻿using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand;
using CrossPlatformChatApp.Domain.Models;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;

namespace CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand {
    public class CreateNewChatHandler(IChatRepository chatRepository, IUserRepository userRepository, IMapper mapper, ILogger<CreateNewChatHandler> logger) : IRequestHandler<CreateNewChatCommand, CreateNewChatCommandResponse> {
        private readonly IChatRepository _chatRepository = chatRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateNewChatHandler> _logger = logger;

        public async Task<CreateNewChatCommandResponse> Handle(CreateNewChatCommand request, CancellationToken cancellationToken) {


            var createNewChatCommandResponse = new CreateNewChatCommandResponse();
            var validator = new CreateNewChatValidator(_chatRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);



            if (validatorResult.Errors.Count > 0) {

                throw new ValidationException(validatorResult);

            } else {

                // Chat setup
                var newChat = new Chat() {
                    Id = Guid.NewGuid(),
                    Name = request.Title
                };
                newChat.Members.Add(request.UserId);

                if(request.Message != null) {
                    var newMessage = new Message() {
                        UserId = request.UserId,
                        Text = request.Message,
                    };
                    newChat.Messages.Add(newMessage);
                }

                // User setup
                var user = new User();

                user = await _userRepository.GetByIdAsync(request.UserId);

                user.Chats.Add(newChat.Id);

                // Friend setup
                var friend = new User();

                if(request.FriendId != null) {
                    newChat.Members.Add(request.FriendId.Value);
                    friend = await _userRepository.GetByIdAsync(request.FriendId.Value);
                    friend.Chats.Add(newChat.Id);
                }


                await _chatRepository.AddAsync(newChat);
                await _userRepository.UpdateAsync(user);
                if(request.FriendId != null) {
                    await _userRepository.UpdateAsync(friend);
                }


                try {

                    createNewChatCommandResponse.Data = _mapper.Map<CreateNewChatCommandVm>(newChat);

                } catch (Exception ex) {

                    string message = $"User Id ({request.UserId}) try to Create a chat ({request.Title}) did not get constructed - {request} - {ex.Message}";
                    _logger.LogError(message);

                }
            }
            return createNewChatCommandResponse;
        }
    }
}
