using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;

namespace CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand {
    public class SendMessageHandler(IMessageRepository messageRepository, IMapper mapper, ILogger<SendMessageHandler> logger) : IRequestHandler<SendMessageCommand, SendMessageCommandResponse> {
        private readonly IMessageRepository _messageRepository = messageRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<SendMessageHandler> _logger = logger;
        public async Task<SendMessageCommandResponse> Handle(SendMessageCommand request, CancellationToken cancellationToken) {

            var sendMessageResponse = new SendMessageCommandResponse();
            var validator = new SendMessageValidator(_messageRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);



            if (validatorResult.Errors.Count > 0) {

                throw new ValidationException(validatorResult);

            } else {

                var newMessage = new Message() { 
                    IsImage = request.IsImage, 
                    Text = request.Message, 
                    UserId = request.Sender, 
                    Created = DateTime.Now };

                await _messageRepository.AddMessage(request.ChatId, newMessage);

                try {

                    sendMessageResponse.Data = _mapper.Map<SendMessageCommandVm>(newMessage);

                } catch (Exception ex) {

                    string message = $"User Id ({request.Sender}) try to send message ({request.Message}) to chat ({request.ChatId}) did not get registered- {request} - {ex.Message}";
                    _logger.LogError(message);

                }
            }
            return sendMessageResponse;
        }
    }
}
