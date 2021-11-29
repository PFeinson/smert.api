using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using smert.Models;
using smert.Repositories;
using System;
using System.Collections;
namespace smert.Services { 
    public class UserService : IUserService {
            private readonly ILogger<UserService> _logger;
            private readonly IUserRepository _userRepository;
         public UserService(ILogger<UserService> logger, IUserRepository userRepository) {
            _logger = logger;
            _userRepository = userRepository;
        }
        /*
        public async Task InsertNewUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId ) {                                            
            return new Task<User>(new User(await _userRepository.InsertNewUser(userId, userName, emailAddress, password, title, firstName, middleName, lastName, suffix, gender, referralUserId)));
        }
        */
        public async Task<object> GetUser(int userId) {
            return await _userRepository.GetUser(userId);                
        }
                                           
    }
}