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
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public IActionResult getAllChannels()
        {
            var result = _channelService.getAllChannels();
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }

        [HttpPost]
        public IActionResult addChannels([FromBody] ChannelTransferObject channel)
        {
            var result = _channelService.addChannel(channel);
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }

        [HttpGet]
        [Route("{user}")]
        public IActionResult getChannelsByUser(string user)
        {
            var result = _channelService.getChannelsByUser(user);
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }
        
        [HttpPost]
        [Route("/api/[controller]/{id}/{username}")]
        public IActionResult assignChannelToUser(long id, string username)
        {
            var result = _channelService.assignChannelToUser(id,username);
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }
    }
}
