using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.SERVICE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult getAllMessages()
        {
            var messages = _messageService.getAllMessages();
            if (messages.ResponseCode == ResponseCode.Success)
                return Ok(messages.Result);
            return BadRequest(messages.Error);
        }

        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public IActionResult getMessageByChannel(long id)
        {
            var messages = _messageService.getMessagesByChannel(id);
            if (messages.ResponseCode == ResponseCode.Success)
                return Ok(messages.Result);
            return BadRequest(messages.Error);
        }

        [HttpPost]
        public IActionResult addMessage([FromBody] MessageTransferObject message)
        {
            var newMessage = _messageService.addMessage(message);
            if (newMessage.ResponseCode == ResponseCode.Success)
                return Ok(newMessage.Result);
            return BadRequest(newMessage.Error);
        }
    }
}
