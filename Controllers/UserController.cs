using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using smert.Services;
using smert.Models;

namespace smert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService) {
            _logger = logger;
            _userService = userService;
        }
        
        [HttpGet("GetUserById/{id}")]
        public string GetUserById(int id) {
            return _userService.GetUserById(id).ToString();
        }

        [HttpGet("Users/AllUsers")]
        public string Index() {
            return _userService.GetAllUsers().ToString();
        }
        
    }
}