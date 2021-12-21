using System.Reflection.PortableExecutable;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Linq;
using AutoMapper;
using smert.Models;
using smert.Models.ssl;
using smert.Services;
namespace smert.Repositories {
    public class UserRepository : IUserRepository {
        private readonly MySqlConnectionStringBuilder _connectionString;
        private readonly ILogger<UserRepository> _logger;
        private readonly IMapper _mapper;
        private int lastUserId;
        public UserRepository(ILogger<UserRepository> logger, IMapper mapper, MySqlConnectionStringBuilder connectionString) {
            _logger = logger;
            _mapper = mapper;
            _connectionString = connectionString;
        }
        
        public async Task<User?> GetUserById(int userId) {
            // Temporary until we called stored procedures
            string query = $"SELECT *\n"+
                            $"FROM user\n"+
                            $"WHERE user_id={userId};";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(_connectionString.ConnectionString)) {
                    await conn.OpenAsync();
                    // Let the user know that its starting the MySqlConnection
                    Console.WriteLine("Opening MySqlConnection!");
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // Read Result from query with MySqlDataReader into a List<User>                    
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        while (rdr.Read()) {
                            Object[] values = new Object[rdr.FieldCount];
                            int fieldCount = rdr.GetValues(values);
                            // Assign Values to new User Object
                            var newUser = new User()
                            {
                                userId = (rdr.IsDBNull(0)) ? null : (int)values[0],
                                userName = (rdr.IsDBNull(1)) ? null : (string)values[1],
                                emailAddress = (rdr.IsDBNull(2)) ? null : (string)values[2],
                                password = (rdr.IsDBNull(3)) ? null : (string)values[3],
                                title = (rdr.IsDBNull(4)) ? null : (string)values[4],
                                firstName = (rdr.IsDBNull(5)) ? null : (string)values[5],
                                middleName = (rdr.IsDBNull(6)) ? null : (string)values[6],
                                lastName = (rdr.IsDBNull(7)) ? null : (string)values[7],
                                suffix = (rdr.IsDBNull(8)) ? null : (string)values[8],
                                gender = (rdr.IsDBNull(9)) ? null : (string)values[9],
                                referralUserId = (rdr.IsDBNull(10)) ? null : (int)values[10],
                                createTimestamp = (DateTime)values[11],
                                suppressTimestamp = (rdr.IsDBNull(12)) ? null : (DateTime)values[12],
                                suppressUserId = (rdr.IsDBNull(13)) ? null : (int)values[13],
                                modifyTimestamp = (rdr.IsDBNull(14)) ? null : (DateTime)values[14],
                                modifyUserId = (rdr.IsDBNull(15)) ? null : (int)values[15]
                            };
                        conn.Close();
                        return newUser;       
                        }
                    }
                    return null;         
                }  
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<User>?> GetAllUsers() {
         // Temporary until we called stored procedures
            string query = $"SELECT * \n"+
                            $"FROM user";
            try{
                List<User> allUsers = null;
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(_connectionString.ConnectionString)) {  
                    conn.Open();
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    await cmd.ExecuteNonQueryAsync(); 
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        allUsers = new List<User>();
                        // Let the user know that 
                        Console.WriteLine("Opening MySqlConnection!");
                        // While there are results contained withint he MySqlDataReader, iterate through and print each  
                        while (rdr.Read()) {
                            Object[] values = new Object[rdr.FieldCount];
                            int fieldCount = rdr.GetValues(values);
                            var newUser = new User()
                            {
                                userId = (rdr.IsDBNull(0)) ? null : (int)values[0], 
                                userName = (rdr.IsDBNull(1)) ? null : (string)values[1],
                                emailAddress = (rdr.IsDBNull(2)) ? null : (string)values[2],
                                password = (rdr.IsDBNull(3)) ? null : (string)values[3],
                                title = (rdr.IsDBNull(4)) ? null : (string)values[4],
                                firstName = (rdr.IsDBNull(5)) ? null : (string)values[5],
                                middleName = (rdr.IsDBNull(6)) ? null : (string)values[6],
                                lastName = (rdr.IsDBNull(7)) ? null : (string)values[7],
                                suffix = (rdr.IsDBNull(8)) ? null : (string)values[8],
                                gender = (rdr.IsDBNull(9)) ? null : (string)values[9],
                                referralUserId = (rdr.IsDBNull(10)) ? null : (int)values[10],
                                createTimestamp = (DateTime)values[11],
                                suppressTimestamp = (rdr.IsDBNull(12)) ? null : (DateTime)values[12],
                                suppressUserId = (rdr.IsDBNull(13)) ? null : (int)values[13],
                                modifyTimestamp = (rdr.IsDBNull(14)) ? null : (DateTime)values[14],
                                modifyUserId = (rdr.IsDBNull(15)) ? null : (int)values[15]
                            };
                            allUsers.Add(newUser);
                        }    
                    }
                    // Print 'Closing MySql' message to console
                    Console.WriteLine("Closing MySqlConnection!");
                    if (allUsers.Equals(null)) {
                        return null;
                    } else {
                        lastUserId = allUsers.Count+1;
                        Console.WriteLine(lastUserId);
                        return allUsers.Count == 0 ? ( new List<User> { } ) : allUsers  ;
                    }
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }    
        }   
        
        public async Task<string> AddUser(string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId){
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(_connectionString.ConnectionString)) {  
                    // Build MySqlCommand
                    using (MySqlCommand cmd = new MySqlCommand("usp_add_user", conn)) {
                        
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySqlParameter("@int_user_id", 5));
                        cmd.Parameters["@int_user_id"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new MySqlParameter("@str_user_name", userName));
                        cmd.Parameters["@str_user_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_email_address", emailAddress));
                        cmd.Parameters["@str_email_address"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_password", password));
                        cmd.Parameters["@str_password"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_title", title));
                        cmd.Parameters["@str_title"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_first_name", firstName));
                        cmd.Parameters["@str_first_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_middle_name", middleName));
                        cmd.Parameters["@str_middle_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_last_name", lastName));
                        cmd.Parameters["@str_last_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_suffix", suffix));
                        cmd.Parameters["@str_suffix"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_gender", gender));
                        cmd.Parameters["@str_gender"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@int_referral_user_id", referralUserId));
                        cmd.Parameters["@int_referral_user_id"].Direction = ParameterDirection.Input;
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    Console.WriteLine("Closing MySqlConnection!");
                    // Close connection
                    conn.Close();
                    return $"User {userName} Added!";
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }    
        }

        public async Task<string> UpdateUser(int userId, string userName, string emailAddress, string password, string? title,
                                        string? firstName, string? middleName, string? lastName, string? suffix, string? gender,
                                        int? referralUserId, int? modifyUserId)
        {
            try
            {
                // The user who is modifying this record is suppressing the previous one
                int? suppressUserId = modifyUserId;
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(_connectionString.ConnectionString))
                {
                    // Build MySqlCommand
                    using (MySqlCommand cmd = new MySqlCommand("usp_update_user", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySqlParameter("@int_user_id", userId));
                        cmd.Parameters["@int_user_id"].Direction = ParameterDirection.InputOutput ;
                        cmd.Parameters.Add(new MySqlParameter("@str_user_name", userName));
                        cmd.Parameters["@str_user_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_email_address", emailAddress));
                        cmd.Parameters["@str_email_address"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_password", password));
                        cmd.Parameters["@str_password"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_title", title));
                        cmd.Parameters["@str_title"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_first_name", firstName));
                        cmd.Parameters["@str_first_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_middle_name", middleName));
                        cmd.Parameters["@str_middle_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_last_name", lastName));
                        cmd.Parameters["@str_last_name"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_suffix", suffix));
                        cmd.Parameters["@str_suffix"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@str_gender", gender));
                        cmd.Parameters["@str_gender"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@int_referral_user_id", referralUserId));
                        cmd.Parameters["@int_referral_user_id"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@int_modify_user_id", modifyUserId));
                        cmd.Parameters["@int_modify_user_id"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@int_suppress_user_id", suppressUserId));
                        cmd.Parameters["@int_suppress_user_id"].Direction = ParameterDirection.Input;
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    Console.WriteLine("Closing MySqlConnection!");
                    return $"User {userName} Updated!";
                }
                // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) { 
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }
        }

        public async Task<string> DeleteUser(int userId) {
            string query = $"DELETE FROM user WHERE user_id = {userId}";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(_connectionString.ConnectionString)) {  
                    // Build MySqlCommand
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    Console.WriteLine("Closing MySqlConnection!");
                    // Close connection
                    conn.Close();
                    return $"User with userId {userId} has been deleted!";
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }    
        }
        public async Task<string> UpdateUserIDIncrementer() {
            string query = $"ALTER TABLE user AUTO_INCREMENT = {lastUserId}";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(_connectionString.ConnectionString)) {  
                    // Build MySqlCommand
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    Console.WriteLine("Closing MySqlConnection!");
                    // Close connection
                    conn.Close();
                    return $"Updated AutoIncrementer!";
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }    
        }
    }
}