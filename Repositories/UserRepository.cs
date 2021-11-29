
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using smert.Models;
using smert.Services;
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

namespace smert.Repositories {
    public class UserRepository : IUserRepository {
        private readonly ILogger<UserRepository> _logger;
        private readonly IMapper _mapper;
        public UserRepository(ILogger<UserRepository> logger, IMapper mapper) {
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<User> GetUserById(int userId) {
            // Temporary until we called stored procedures
            string query = $"SELECT TOP 1 FROM\n"+
                            $"user WHERE user_id = {userId}";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(getConnectionString())) {
                    // Let the user know that 
                    Console.WriteLine("Opening MySqlConnection!");
                    conn.Open();
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // Read Result from query with MySqlDataReader into a List<User>                    
                    var returnableUser = (User)cmd.ExecuteScalar();
                    return returnableUser;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return new User();
            }
        }

        public async Task<List<User>> GetAllUsers() {
            Console.WriteLine("Enters this method successfully! UserRepository.GetAllUsers()");
         // Temporary until we called stored procedures
            string query = $"SELECT * "+
                            $"FROM user"+
                            $"SORT BY ASCENDING;";
            try{
                List<User> allUsers = null;
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(getConnectionString())) {  
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        // Let the user know that 
                        Console.WriteLine("Opening MySqlConnection!");
                        conn.Open();
                        cmd.ExecuteNonQueryAsync();
                        // While there are results contained withint he MySqlDataReader, iterate through and print each  
                        while (rdr.Read()) {
                            allUsers.Add((User)(_mapper.Map<object, User>(rdr)));
                        }    
                    }
                    // Print 'Closing MySql' message to console
                    Console.WriteLine("Closing MySqlConnection!");
                    // Close connection
                    conn.Close();
                    if (allUsers.Count == 0)
                        return new List<User>();
                    return allUsers; 
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return new List<User>();
            }    
        }   

        // This will be replaced by appsettings, or Secretsmanager or something. Exists now to keep things moving and create a proper connection string
        public string getConnectionString() {
            string server = "34.152.7.147";
            string port = "3308";
            string database = "dev-smert-db";
            string uid = "dev-access-account";
            string password = "password";
            string ssl_ca = ".ssl/server-ca.pem";
            string ssl_cert = ".ssl/client-cert.pem";
            string ssl_key = ".ssl/client-key.pem";
            string connectionString = $"SERVER={server};DATABASE={database};PORT={port};UID={uid};PASSWORD={password};ssl-ca={ssl_ca};ssl-cert={ssl_cert};ssl_key{ssl_key};";
            return connectionString;
        }
   
    }
}