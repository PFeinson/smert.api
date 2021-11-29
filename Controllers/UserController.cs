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
    public class UserController : ControllerBase {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        public UserController(ILogger<UserController> logger, UserService userService) {
            _logger = logger;
            _userService = userService;
        }
        /*
        [HttpGet("{id}"]
        public IActionResult Get(int id) {
            return (IActionResult)_userService.SelectFromUserTable(0);
        }
        */
    }
}