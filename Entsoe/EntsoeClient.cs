using Entsoe.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Xml;

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

        private RestRequest GetBasicRequest(DateTime start, DateTime end)
        {
            var request = new RestRequest();

            request.AddParameter("securityToken", _apiKey);
            request.AddParameter("periodStart", start);
            request.AddParameter("periodEnd", end);

            return request;
        }

        private static AreaInfoAttribute GetAreaInfo(Area area)
        {
            var obj = area.GetType()
                    .GetMember(area.ToString())
                    .First()
                    .GetCustomAttribute<AreaInfoAttribute>();
            if (obj == null)
            {
                throw new Exception("");
            }

            return obj;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="dayAhead"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryNetPosition(
            Area area,
            DateTime start,
            DateTime end,
            bool dayAhead = true
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = GetBasicRequest(start, end);
            request.AddParameter("in_Domain", areaInfo.Domain);
            request.AddParameter("out_Domain", areaInfo.Domain);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A25));
            request.AddParameter("businessType", Enum.GetName(typeof(BusinessType), BusinessType.B09));
            if (dayAhead)
                request.AddParameter("Contract_MarketAgreement.Type", Enum.GetName(typeof(MarketAgreementType), MarketAgreementType.A01));
            else
                request.AddParameter("Contract_MarketAgreement.Type", Enum.GetName(typeof(MarketAgreementType), MarketAgreementType.A07));

            

            var response = await _client.ExecuteGetAsync(request);

            if(response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public async Task<BalancingMarketDocument> QueryDayAheadPrices(
            Area area,
            DateTime start,
            DateTime end
        )
        {
            var areaInfo = GetAreaInfo(area);
            var request = GetBasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A44));
            request.AddParameter("in_Domain", areaInfo.Domain);
            request.AddParameter("out_Domain", areaInfo.Domain);

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                XmlDocument doc = new();
                doc.LoadXml(response.Content!);

                string json = JsonConvert.SerializeXmlNode(doc);
                return JsonConvert.DeserializeObject<BalancingMarketDocument>(json)!;
            }
            else
            {
                throw new Exception("");
            }


        }

    }
}