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
        [Produces("application/json")]
        public async Task<ActionResult<User>> GetUserById(int id) {
            var fetchedUser = await _userService.GetUserById(id);
            if( fetchedUser != null )  
                return (fetchedUser.Equals(new User()) ? NotFound("Service Returned Empty User") : Ok(fetchedUser));
            else {
                return NoContent();
            }
        }

        [HttpGet("/GetAllUsers/")]
        [Produces("application/json")]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            List<User> allUsers = await _userService.GetAllUsers();
            if (allUsers != null && allUsers.Count > 0) {
                return allUsers == new List<User>() ? NotFound("Service Returned a new List of Users!") : Ok(allUsers);
            } else {
                return NoContent();
            }
        }
        
        [HttpPut("/AddUser/")]
        [Produces("application/json")]
        public async Task<ActionResult<string>> AddUser(string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId) {
            var result = await _userService.AddUser(userName, emailAddress, password, title, firstName, middleName, lastName, suffix, gender, referralUserId);
            if (result == $"User {userName} Added!")
            {
                return Ok(result);
            } else
            {
                return (result == null ? NoContent() : NotFound());
            }
        }

        [HttpPatch("/ModifyUser/")]
        [Produces("application/json")]
        public async Task<ActionResult<string>> UpdateUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId, int? modifyUserId)
        {
            var result = await _userService.UpdateUser(userId, userName, emailAddress, password, title, firstName, middleName, lastName, suffix, gender, referralUserId, modifyUserId);
            if (result == $"User {userName} Updated!")
            {
                return Ok(result);
            }
            else
            {
                return (result == null ? NoContent() : NotFound());
            }
        }

        [HttpDelete("/DeleteUser/{userId}/")]
        [Produces("application/json")]
        public async Task<ActionResult<string>> DeleteUser(int userId) {
            var result = await _userService.DeleteUser(userId);
            if (result == $"User with userId {userId} has been deleted!") {
                return Ok(result);
            } else {
                return (result == null ? NoContent() : NotFound());
            }
        }

        [HttpPatch("/UpdateUserIDIncrementer/")]
        [Produces("application/json")]
        public async Task<ActionResult<string>> UpdateUserIDIncrementer() {
            var result = await _userService.UpdateUserIDIncrementer();
            if (result == $"Updated AutoIncrementer!"){
                return Ok(result);
            } else {
                return (result == null ? NoContent() : NotFound());
            }
        }

    }
}