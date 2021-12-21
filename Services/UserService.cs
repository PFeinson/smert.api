using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using smert.Models;
using smert.Repositories;
using System;
using System.Collections.Generic;
namespace smert.Services { 
    public class UserService : IUserService {
            private readonly ILogger<UserService> _logger;
            private readonly IUserRepository _userRepository;
         public UserService(ILogger<UserService> logger, IUserRepository userRepository) {
            _logger = logger;
            _userRepository = userRepository;
        }
        
        public async Task<User> GetUserById(int userId) {
            return await _userRepository.GetUserById(userId);                
        }

        public async Task<List<User>> GetAllUsers() {
            return await _userRepository.GetAllUsers();
        }

        public async Task<string> AddUser(string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId)
        {
            return await _userRepository.AddUser(userName, emailAddress, password, title, firstName, middleName, lastName, suffix, gender, referralUserId);
        }


        public async Task<string> UpdateUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId, int? modifyUserId)
        {
            return await _userRepository.UpdateUser(userId, userName, emailAddress, password, title, firstName, middleName, lastName, suffix, gender, referralUserId, modifyUserId);
        }

        public async Task<string> DeleteUser(int userId) {
            return await _userRepository.DeleteUser(userId);
        }
    }
}