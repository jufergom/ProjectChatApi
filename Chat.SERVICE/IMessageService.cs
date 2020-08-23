using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.SERVICE
{
    public interface IMessageService
    {
        public ServiceResult<MessageTransferObject> addMessage(MessageTransferObject message);

        public ServiceResult<IEnumerable<MessageTransferObject>> getAllMessages();

        public ServiceResult<IEnumerable<MessageTransferObject>> getMessagesByChannel(long id);
    }
}
