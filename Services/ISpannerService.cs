using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Google.Cloud.Spanner.Data;
using System;
using System.Threading.Tasks;

namespace smert.Services {
    public interface ISpannerService {
        public async Task ExecuteSelectQueryAsync(string query) {}


    }
}