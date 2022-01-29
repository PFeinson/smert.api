using smert.Services;
using smert.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
namespace smert.Repositories {
    public interface IUserRepository {
        Task<User> GetUserById(int userId);
        Task<List<User>> GetAllUsers();
        
        Task<string> AddUser(string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId );

        Task<string> UpdateUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId, int? modifyUserId);
        
        Task<string> DeleteUser(int userId);

        Task<string> UpdateUserIDIncrementer();

        Task<User> login(string password, string userName);

    }
}