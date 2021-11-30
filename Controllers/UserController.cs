using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using smert.Services;
using smert.Models;
using smert.Models.DTO;
using AutoMapper;
using Newtonsoft.Json;

namespace smert.Controllers
{
    [Route("User/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, ILogger<UserController> logger, IUserService userService) {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }
        [HttpGet("/GetUserById/{id}/")]
        public async Task<ActionResult<User>> GetUserById(int id) {
            var fetchedUser = await _userService.GetUserById(id);
            return fetchedUser != null ? Ok(fetchedUser) : NotFound("service returned null!");
        }

        [HttpGet("/DoesThisEvenWork/")]
        public async Task<ActionResult<string>> TestReturnsAnything() {
            return Ok("this is a test");
        }

        [HttpGet("/GetAllUsers/")]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            List<User> allUsers = new List<User>() { _mapper.Map<User>(await _userService.GetAllUsers()) };
            return allUsers.Count > 0 ? Ok(allUsers) : NoContent();
        }
        
    }
}