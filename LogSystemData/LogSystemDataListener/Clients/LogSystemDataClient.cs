using System;
using System.Net.Http;

namespace LogSystemDataListener.Clients
{
    public class LogSystemDataClient : ILogSystemDataClient
    {
        private readonly HttpClient _httpClient;
        private const Uri _inventoryApiUrl;

        public LogSystemDataClient( HttpClient httpClient )
        {
            _httpClient = httpClient;

        }
    }
}