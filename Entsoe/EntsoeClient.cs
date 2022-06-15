using RestSharp;

namespace Entsoe
{
    /// <summary>
    ///  Client to perform API calls and return the raw responses API-documentation:
    /// https://transparency.entsoe.eu/content/static_content/Static%20content/web%20api/Guide.html#_request_methods
    /// Attributions: Parts of the code for parsing Entsoe responses were copied
    /// from https://github.com/tmrowco/electricitymap
    /// </summary>
    public class EntsoeClient
    {
        private readonly RestClient _client;
        private readonly string _apiKey;
        private const string _entsoeUrl = "https://transparency.entsoe.eu/api";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public EntsoeClient(string apiKey)
        {
            _apiKey = apiKey;
            var options = new RestClientOptions(_entsoeUrl) 
            { 
                Timeout = 30000
            };
            _client = new RestClient(options);
        }



    }
}