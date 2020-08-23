using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.SERVICE
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;

        public MessageService(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public ServiceResult<MessageTransferObject> addMessage(MessageTransferObject message)
        {
            var newMessage = new Message
            {
                userTag = message.username,
                message = message.message,
                channelId = message.channelId
            };

            _messageRepository.Add(newMessage);
            _messageRepository.saveChanges();
            message.id = newMessage.id;

            return ServiceResult<MessageTransferObject>.SuccessResult(message);
        }

        public ServiceResult<IEnumerable<MessageTransferObject>> getAllMessages()
        {
            var messages = _messageRepository.All()
                .Select(x=> new MessageTransferObject {
                    id = x.id,
                    channelId = x.channelId,
                    username = x.userTag,
                    message = x.message
                }).ToList();

            return ServiceResult<IEnumerable<MessageTransferObject>>.SuccessResult(messages);
        }

        public ServiceResult<IEnumerable<MessageTransferObject>> getMessagesByChannel(long id)
        {
            var messages = _messageRepository.All()
                .Where(x => x.channelId == id)
                .Select(x => new MessageTransferObject
                {
                    id = x.id,
                    channelId = x.channelId,
                    username = x.userTag,
                    message = x.message
                }).ToList();

            return ServiceResult<IEnumerable<MessageTransferObject>>.SuccessResult(messages);
        }
    }
}
