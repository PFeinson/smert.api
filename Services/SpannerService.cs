using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Google.Cloud.Spanner.Data;
using System;
using System.Threading.Tasks;
using smert.Models;
using System.Linq;
using System.Linq.Expressions;

namespace smert.Services {

    public class SpannerService : ISpannerService {
        public async Task ExecuteSelectQueryAsync(string query) {
            string projectId = "keen-extension-331705";
            string instanceId = "smert-test-db-1";
            string databaseId = "prod";
            string connectionString = $"Data Source=projects/{projectId}/instances/{instanceId}/databases/{databaseId}";
            // Create connection to Cloud Spanner
            using (var connection = new SpannerConnection(connectionString)) {
                // Execute a simple SQL statement
using             using($"{query} as result");
using                    return reader;
                }
            }
        }

        public async Task ExecuteWriteQueryAsync(string query) {
            string projectId = "keen-extension-331705";
            string instanceId = "smert-test-db-1";
            string databaseId = "prod";
            string connectionString = $"Data Source=projects/{projectId}/instances/{instanceId}/databases/{databaseId}";
            // Create connection to Cloud Spanner
            using (var connection = new SpannerConnection(connectionString)) { 
                // Execute a simple SQL statement
                var cmd = connection.SpannerCommand(query);
            }
        }
    }
}