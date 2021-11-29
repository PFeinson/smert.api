using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using smert.Services;
using smert.Models;
using smert.Models.DTO;
using AutoMapper;

namespace smert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, ILogger<UserController> logger, IUserService userService) {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }
        
        [HttpGet("GetUserById/{id}")]
        public async Task<User> GetUserById(int id) {
            return _mapper.Map<User>(await _userService.GetUserById(id));
        }

        [HttpGet("DoesThisEvenWork")]
        public string TestReturnsAnything() {
            return ("this is a test");
        }

        [HttpGet("GetAllUsers")]
        public async Task<List<User>> GetAllUsers() {
            Console.WriteLine("Does it even get this far?");
            return await _userService.GetAllUsers();
        }
        
    }
}