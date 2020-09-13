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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult getUsers()
        {
            var userResult = _userService.getAll();
            if (userResult.ResponseCode == ResponseCode.Success)
                return Ok(userResult.Result);
            return BadRequest(userResult.Error);
        }
        [HttpPost]
        public IActionResult addUsers([FromBody] UserTransferObject user)
        {
            var userResult = _userService.AddUser(user);
            if (userResult.ResponseCode == ResponseCode.Success)
                return Ok(userResult.Result);
            return BadRequest(userResult.Error);
        }

        [HttpPost]
        [Route("/api/[controller]/credentials")]
        public IActionResult checkUser([FromBody] UserTransferObject user)
        {
            var userResult = _userService.checkCredentials(user);
            if (userResult.ResponseCode == ResponseCode.Success)
                return Ok(userResult.Result);
            return BadRequest(false);
        }
    }
}
