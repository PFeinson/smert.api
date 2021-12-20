using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using smert.Models;
using smert.Services;
using smert.Repositories;
namespace smert.Services {
    public interface IUserService {
        
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();

        Task<string> AddUser(int userId, string userName, string emailAddress, string password, string? title,
                                       string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                       int? referralUserId);

        Task<string> UpdateUser (int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId, int? modifyUserId);
            
    }
}