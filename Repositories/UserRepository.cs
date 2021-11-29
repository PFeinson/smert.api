
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
        public async Task<object> GetUser(int userId) {
            string query = $"SELECT TOP 1 FROM"+
                            $"user WHERE user_id = {userId}";
            try{
                using (var conn = new MySqlConnection(getConnectionString())) {
                    Console.WriteLine("Opening MySqlConnection!");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    Dictionary<string, string> output = new Dictionary<string, string>();
                    while (rdr.Read()) {
                        output[$"{rdr[0]}"] = $"{rdr[1]}";
                        Console.WriteLine($"{rdr[0]} {rdr[1]}");
                    }
                    Console.WriteLine("Closing MySqlConnection!");
                    conn.Close();
                    return output;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Exception: {ex.ToString()}");
                return ex;
            }
        }   

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