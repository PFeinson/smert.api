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
    [Route("LoginAndRegistration/[controller]")]
    [ApiController]
    public class LoginAndRegistrationController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly ILogger<LoginAndRegistrationController> _logger;
        private readonly IUserService _userService;
        public LoginAndRegistrationController(IMapper mapper, ILogger<LoginAndRegistrationController> logger, IUserService userService) {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("/Registration/")]
        [Produces("application/json")]
        public async Task<ActionResult<User>> Registration(string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId) {

            var result = await _userService.AddUser(userName, emailAddress, password, title, firstName, middleName, lastName, suffix, gender, referralUserId);
            if (result == $"User {userName} Added!")
            {
                return Ok(result);
            } 
            return (result == null ? NoContent() : NotFound());
                
        }

        [HttpGet("/Login/")]
        [Produces("application/json")]
        public async Task<ActionResult<User>> Login(string userName, string password) {
            User loggedInUser = await _userService.login(userName, password);
            
            if (loggedInUser != null) {
                return loggedInUser.userId == null ? NotFound("Password Invalid") : Ok(loggedInUser);
            } 
            return NotFound("User not found!");
        }
    }
}