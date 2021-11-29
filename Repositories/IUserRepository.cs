using smert.Services;
using smert.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
namespace smert.Repositories {
    public interface IUserRepository {
        /*
        Task InsertNewUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId );
        */
        Task<object> GetUser(int userId);                                
        
    }
}