
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
                            var newUser = new User()
                            {
                                userId = (int)rdr[0], 
                                userName = (string)rdr[1],
                                emailAddress = (rdr.IsDBNull(2)) ? null : (string)values[2],
                                password = (rdr.IsDBNull(3)) ? null : (string)values[3],
                                title = (rdr.IsDBNull(4)) ? null : (string)values[4],
                                firstName = (string)values[5],
                                middleName = (rdr.IsDBNull(6)) ? null : (string)values[6],
                                lastName = (string)values[7],
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
                                userId = (int)values[0], 
                                userName = (string)values[1],
                                emailAddress = (rdr.IsDBNull(2)) ? null : (string)values[2],
                                password = (rdr.IsDBNull(3)) ? null : (string)values[3],
                                title = (rdr.IsDBNull(4)) ? null : (string)values[4],
                                firstName = (string)values[5],
                                middleName = (rdr.IsDBNull(6)) ? null : (string)values[6],
                                lastName = (string)values[7],
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
                    // Close connection
                    conn.Close();
                    if (allUsers.Equals(null)) {
                        return null;
                    } else {
                        return allUsers.Count == 0 ? ( new List<User> { } ) : allUsers  ;
                    }
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }    
        }   
   
    }
}