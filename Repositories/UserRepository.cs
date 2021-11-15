
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using smert.Models;
using smert.Services;
using System.Threading.Tasks;
using System;
namespace smert.Repositories {
    public class UserRepository : IUserRepository {
        private readonly ILogger<UserRepository> _logger;
        private readonly SpannerService _spannerService;
        public UserRepository(ILogger<UserRepository> logger, SpannerService spannerService) {
            _logger = logger;
            _spannerService = spannerService;
        }

        public async Task InsertNewUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId ) {
            string query = $"INSERT "+
                            $"INTO user"+
                            $"user_id, user_name, email_address, password, title, first_name, middle_name, last_name, suffix, gender, referral_user_id, create_timestamp"+
                            "{"+
                            // 'password' will need to be hashed once this hits prod
                            $"{userId}, {userName}, {emailAddress}, {password}, {title}, {firstName}, {middleName}, {lastName}, {suffix}, {gender}, {referralUserId}, {DateTime.Now}"+
                            "}";
            return _spannerService.ExecuteWriteQueryAsync(query);                                                
        }

        public async Task SelectFromUserTable(int userId) {
            string query = $"SELECT TOP 1 FROM"+
                            $"user WHERE user_id = {userId}";
            return _spannerService.ExecuteSelectQueryAsync(query);
        }
    }
}