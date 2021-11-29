
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using smert.Models;
using smert.Services;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace smert.Repositories {
    public class UserRepository : IUserRepository {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger) {
            _logger = logger;
        }
        public async Task<object> GetUserById(int userId) {
            // Temporary until we called stored procedures
            string query = $"SELECT TOP 1 FROM"+
                            $"user WHERE user_id = {userId}"+
                            $"SORT BY ASCENDING;";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(getConnectionString())) {
                    // Let the user know that 
                    Console.WriteLine("Opening MySqlConnection!");
                    conn.Open();
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // Read Result from query with MySqlDataReader
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    var output = new List<object>();
                    // While there are results contained withint he MySqlDataReader, iterate through and print each 
                    while (rdr.Read()) {
                        // Print each entry (Idk if this is what we actually want to do?)
                        output.Add(rdr[0] + " " + rdr[1]);
                    }
                    // Print 'Closing MySql' message to console
                    Console.WriteLine("Closing MySqlConnection!");
                    // Close connection
                    conn.Close();
                    // return the result of the query
                    return output;
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return ex;
            }
        }

        public async Task<object> GetAllUsers() {
         // Temporary until we called stored procedures
            string query = $"SELECT * "+
                            $"FROM user"+
                            $"SORT BY ASCENDING;";
            try{
                // Establish MySqlConnection to be used for this DB operation
                using (var conn = new MySqlConnection(getConnectionString())) {
                    // Let the user know that 
                    Console.WriteLine("Opening MySqlConnection!");
                    conn.Open();
                    // Build MySqlCommand
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // Read Result from query with MySqlDataReader
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    // While there are results contained withint he MySqlDataReader, iterate through and print each 
                    List<string> allUsers = new List<string>();   
                    while (rdr.Read()) {
                        // Print each entry (Idk if this is what we actually want to do?)
                        allUsers.Add($"{rdr[0]} {rdr[1]}");
                    }
                    // Print 'Closing MySql' message to console
                    Console.WriteLine("Closing MySqlConnection!");
                    // Close connection
                    conn.Close();
                    // return the result of the query
                    return allUsers;
                }
            // If there's an exception of any kind, print to console and then return the exception
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return ex;
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