using Google.Cloud.Spanner.Data;
using System;
using System.Threading.Tasks;

public class SpannerService {
    public async Task ExecuteSelectQueryAsync(string query) {
        string projectId = "keen-extension-331705";
        string instanceId = "smert-test-db-1";
        string databaseId = "prod";
        string connectionString = $"Data Source=projects/{projectId}/instances/{instanceId}/databases/{databaseId}";
        // Create connection to Cloud Spanner
        using (var connection = new SpannerConnection(connectionString)) {
            // Execute a simple SQL statement
            var cmd = connection.CreateSelectCommand(
                @$"{query} as result");
            using (var reader = await cmd.ExecuteReaderAsync()) {
                while (await reader.ReadAsync()) {
                    Console.WriteLine(
                        reader.GetFieldValue<string>("result")
                    );
                }
            }
        }
    }
}