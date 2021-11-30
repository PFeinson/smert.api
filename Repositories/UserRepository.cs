
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
        private readonly ILogger<UserRepository> _logger;
        private readonly IMapper _mapper;
        public UserRepository(ILogger<UserRepository> logger, IMapper mapper) {
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<User?> GetUserById(int userId) {
            // Temporary until we called stored procedures
            string query = $"SELECT TOP 1 FROM\n"+
                            $"user WHERE user_id = {userId};";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(getConnectionString())) {
                    conn.Open();
                    // Let the user know that its starting the MySqlConnection
                    Console.WriteLine("Opening MySqlConnection!");
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // Read Result from query with MySqlDataReader into a List<User>                    
                    var returnableUser = cmd.ExecuteScalar();
                    conn.Close();
                    return (User)returnableUser;
                }  
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<User>?> GetAllUsers() {
         // Temporary until we called stored procedures
            string query = $"SELECT * \n"+
                            $"FROM user\n"+
                            $"SORT BY ASCENDING creation_date;";
            try{
                List<User> allUsers = null;
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(getConnectionString())) {  
                    conn.Open();
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQueryAsync(); 
                    using (var rdr = await cmd.ExecuteReaderAsync()) {
                        allUsers = new List<User>();
                        // Let the user know that 
                        Console.WriteLine("Opening MySqlConnection!");
                        // While there are results contained withint he MySqlDataReader, iterate through and print each  
                        while (rdr.Read()) {
                            var newUser =  _mapper.Map<object, User>(rdr);
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

        // This will be replaced by appsettings, or Secretsmanager or something. Exists now to keep things moving and create a proper connection string
        public string getConnectionString() {
            string server = "34.152.7.147";
            string port = "3308";
            string uid = "dev-access-account";
            string password = "password";
            // Instantiate objects to read key files through
            // This will be moved somewhere better (TF or Secrets)
            var ssl_ca = new ssl_ca();
            var ssl_cert = new ssl_cert();
            var ssl_key = new ssl_key();
            // Assign them to strings for the connection string
            string sslKey = ssl_key.getPrivateKey();
            string sslCert = ssl_cert.getCertificate();
            string sslCa = ssl_ca.getCertificate();

            string connectionString = $"USER={uid};HOST={server};DATABASE=dev;PORT={port};";
            return connectionString;
        }
   
    }
}