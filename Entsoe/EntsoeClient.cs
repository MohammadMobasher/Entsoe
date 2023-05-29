using Entsoe.Models;
using Entsoe.Models.Result;
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
        private readonly string _apiKey;
        private readonly RestClient _client;
        private const string _entsoeUrl = "https://web-api.tp.entsoe.eu/api";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public EntsoeClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }
            _apiKey = apiKey;
            var options = new RestClientOptions(_entsoeUrl)
            {
                MaxTimeout = 30000
            };
            _client = new RestClient(options);
        }

        private RestRequest BasicRequest(DateTime start, DateTime end)
        {
            //====================================
            var request = new RestRequest();
            //====================================

            request.AddParameter("securityToken", _apiKey);
            request.AddParameter("periodStart", start.ToString("yyyyMMddHH00"));
            request.AddParameter("periodEnd", end.ToString("yyyyMMddHH00"));

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
        /// Generic function called by QueryCrossborderFlows, 
        /// QueryScheduledExchanges, QueryNetTransferCapacity_DA/WA/MA/YA and query_.
        /// </summary>
        /// <param name="areaFrom"></param>
        /// <param name="areaTo"></param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="marketAgreementType"></param>
        /// <param name="businessType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> QueryCrossborder(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end,
            DocumentType documentType,
            MarketAgreementType? marketAgreementType = null,
            BusinessType? businessType = null,
            AuctionType? auctionType = null

        )
        {
            var areaInfoFrom = GetAreaInfo(areaFrom);
            var areaInfoTo = GetAreaInfo(areaTo);

            var request = BasicRequest(start, end);
            request.AddParameter("in_Domain", areaInfoTo.Domain);
            request.AddParameter("out_Domain", areaInfoFrom.Domain);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), documentType));

            if (marketAgreementType != null)
            {
                request.AddParameter("Contract_MarketAgreement.Type", Enum.GetName(typeof(MarketAgreementType), marketAgreementType));
            }

            if (businessType != null)
            {
                request.AddParameter("businessType", Enum.GetName(typeof(BusinessType), businessType));
            }

            if (auctionType != null)
            {
                request.AddParameter("Auction.Type", Enum.GetName(typeof(AuctionType), auctionType));
            }


            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Area</param>
        /// <param name="start">from</param>
        /// <param name="end">to</param>
        /// <param name="marketAgreementType">type of contract (see mappings.MARKETAGREEMENTTYPE)</param>
        /// <param name="psrType">filter query for a specific psr type</param>
        /// <param name="offset">offset for querying more than 100 documents</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryContractedReservePrices(
            Area area,
            DateTime start,
            DateTime end,
            MarketAgreementType marketAgreementType,
            PsrType? psrType = null,
            int offset = 0
        )
        {
            AreaInfoAttribute areaInfo = GetAreaInfo(area);
            RestRequest request = BasicRequest(start, end);

            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A89));
            request.AddParameter("type_MarketAgreement.Type", Enum.GetName(typeof(MarketAgreementType), marketAgreementType));
            request.AddParameter("controlArea_Domain", areaInfo.Domain);
            request.AddParameter("offset", offset);
            if (psrType != null)
                request.AddParameter("psrType", Enum.GetName(typeof(PsrType), psrType));

            var response = await _client.ExecuteGetAsync(request);

            if (response == null || !response.IsSuccessful)
                throw new Exception("Something wrong please try again...");
            
            return response.Content!;
        }


        /// <summary>
        /// Allocated result documents, for OC evolution see QueryIntradayOfferedCapacity
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="implicity">(True = implicit - default for most borders. False = explicit - for instance BE-GB)</param>
        /// <returns></returns>
        public async Task<string> QueryOfferedCapacity(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end,
            bool implicity = true
        )
        {
            return await QueryCrossborder(
                areaFrom,
                areaTo,
                start,
                end,
                documentType: implicity ? DocumentType.A31 : DocumentType.A25,
                marketAgreementType: MarketAgreementType.A07,
                auctionType: implicity ? AuctionType.A01 : AuctionType.A02,
                businessType: implicity ? null : BusinessType.B05);
        }





















        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="implicity">True = implicit - default for most borders. False = explicit - for instance BE-GB</param>
        /// <returns></returns>
        public async Task<string> QueryIntradayOfferedCapacity(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end,
            bool implicity = true
        )
        {
            return await QueryCrossborder(
                areaFrom, 
                areaTo, 
                start, 
                end, 
                documentType: DocumentType.A31, 
                marketAgreementType: MarketAgreementType.A07,
                auctionType: implicity ? AuctionType.A01 : AuctionType.A02);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <returns></returns>
        public async Task<string> QueryNetTransferCapacityYearahead(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end
        )
        {
            return await QueryCrossborder(areaFrom, areaTo, start, end, documentType: DocumentType.A61, marketAgreementType: MarketAgreementType.A04);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <returns></returns>
        public async Task<string> QueryNetTransferCapacityMonthahead(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end
        )
        {
            return await QueryCrossborder(areaFrom, areaTo, start, end, documentType: DocumentType.A61, marketAgreementType: MarketAgreementType.A03);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <returns></returns>
        public async Task<string> QueryNetTransferCapacityWeekahead(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end
        )
        {
            return await QueryCrossborder(areaFrom, areaTo, start, end, documentType: DocumentType.A61, marketAgreementType: MarketAgreementType.A02);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <returns></returns>
        public async Task<string> QueryNetTransferCapacityDayahead(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end
        )
        {
            return await QueryCrossborder(areaFrom, areaTo, start, end, documentType: DocumentType.A61, marketAgreementType: MarketAgreementType.A01);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="dayAhead">if true MarketAgreementType.A01 else MarketAgreementType.A05</param>
        /// <returns></returns>
        public async Task<string> QueryScheduledExchanges(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end,
            bool dayAhead = false
        )
        {
            MarketAgreementType marketAgreementType = dayAhead ? MarketAgreementType.A01 : MarketAgreementType.A05;
            return await QueryCrossborder(areaFrom, areaTo, start, end, documentType: DocumentType.A09, marketAgreementType: marketAgreementType);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaFrom">Country from Area</param>
        /// <param name="areaTo">Country to Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <returns></returns>
        public async Task<string> QueryCrossborderFlows(
            Area areaFrom,
            Area areaTo,
            DateTime start,
            DateTime end
        )
        {
            return await QueryCrossborder(areaFrom, areaTo, start, end, documentType:DocumentType.A11);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="psrType">When used, only queried production type is returned</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryInstalledGenerationCapacityPerUnit(
            Area area,
            DateTime start,
            DateTime end,
            PsrType? psrType = null
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A71));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), ProccessType.A33));
            request.AddParameter("in_Domain", areaInfo.Domain);
            if (psrType != null)
                request.AddParameter("psrType", Enum.GetName(typeof(PsrType), psrType));

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="psrType">When used, only queried production type is returned</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryInstalledGenerationCapacity(
            Area area,
            DateTime start,
            DateTime end,
            PsrType? psrType = null
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A68));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), ProccessType.A33));
            request.AddParameter("in_Domain", areaInfo.Domain);
            if (psrType != null)
                request.AddParameter("psrType", Enum.GetName(typeof(PsrType), psrType));

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="psrType">When used, only queried production type is returned</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryGenerationPerPlant(
            Area area,
            DateTime start,
            DateTime end,
            PsrType? psrType = null
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A73));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), ProccessType.A16));
            request.AddParameter("in_Domain", areaInfo.Domain);
            if (psrType != null)
                request.AddParameter("psrType", Enum.GetName(typeof(PsrType), psrType));

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="psrType">When used, only queried production type is returned</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryGeneration(
            Area area,
            DateTime start,
            DateTime end,
            PsrType? psrType = null
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A75));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), ProccessType.A16));
            request.AddParameter("in_Domain", areaInfo.Domain);
            if (psrType != null)
                request.AddParameter("psrType", Enum.GetName(typeof(PsrType), psrType));

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="proccessType">
        /// default value is ProccessType.A01 => Day ahead
        /// </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryGenerationForecast(
            Area area,
            DateTime start,
            DateTime end,
            ProccessType proccessType = ProccessType.A01
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A71));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), proccessType));
            request.AddParameter("in_Domain", areaInfo.Domain);

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="proccessType"></param>
        /// <param name="psrType">When used, only queried production type is returned</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryWindAndSolarForecast(
            Area area,
            DateTime start,
            DateTime end,
            ProccessType proccessType = ProccessType.A01,
            PsrType? psrType = null)
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A69));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), proccessType));
            request.AddParameter("in_Domain", areaInfo.Domain);

            if (psrType != null)
                request.AddParameter("psrType", Enum.GetName(typeof(PsrType), psrType));

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="proccessType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryLoadForecast(
            Area area,
            DateTime start,
            DateTime end,
            ProccessType proccessType = ProccessType.A01)
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A65));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), proccessType));
            request.AddParameter("outBiddingZone_Domain", areaInfo.CountryCode);

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> QueryLoad(
            Area area,
            DateTime start,
            DateTime end
        )
        {
            var areaInfo = GetAreaInfo(area);

            var request = BasicRequest(start, end);
            request.AddParameter("out_Domain", areaInfo.Domain);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A65));
            request.AddParameter("processType", Enum.GetName(typeof(ProccessType), ProccessType.A16));
            request.AddParameter("outBiddingZone_Domain", areaInfo.CountryCode);

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        /// <param name="dayAhead">
        /// if set true, return data Daily and if false return Intraday
        /// </param>
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

            var request = BasicRequest(start, end);
            request.AddParameter("in_Domain", areaInfo.Domain);
            request.AddParameter("out_Domain", areaInfo.Domain);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A25));
            request.AddParameter("businessType", Enum.GetName(typeof(BusinessType), BusinessType.B09));
            if (dayAhead)
                request.AddParameter("Contract_MarketAgreement.Type", Enum.GetName(typeof(MarketAgreementType), MarketAgreementType.A01));
            else
                request.AddParameter("Contract_MarketAgreement.Type", Enum.GetName(typeof(MarketAgreementType), MarketAgreementType.A07));
           


            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                return response.Content!;
            }
            throw new Exception("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">Country from Area</param>
        /// <param name="start">Time for start period</param>
        /// <param name="end">Time for end period</param>
        public async Task<BalancingMarketDocument> QueryDayAheadPrices(
            Area area,
            DateTime start,
            DateTime end
        )
        {
            var areaInfo = GetAreaInfo(area);
            var request = BasicRequest(start, end);
            request.AddParameter("documentType", Enum.GetName(typeof(DocumentType), DocumentType.A44));
            request.AddParameter("in_Domain", areaInfo.Domain);
            request.AddParameter("out_Domain", areaInfo.Domain);

            var response = await _client.ExecuteGetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                XmlDocument doc = new();
                doc.LoadXml(response.Content!);

                doc.RemoveChild(doc.FirstChild);

                string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);

                CheckValidResponse(json);

                return JsonConvert.DeserializeObject<BalancingMarketDocument>(json)!;
            }
            else
            {
                if (response == null)

                    throw new Exception("Response is empty");
                else
                {
                    throw new Exception(String.Format("There is an error on fetching data, StatusCode : {0}, ", response.StatusCode));
                }


            }
        }


        private void CheckValidResponse(string input)
        {
            var result = JsonConvert.DeserializeObject<AcknowledgementMarketDocument>(input)!;

            if (result.Reason.Code == 999)
            {
                throw new Exception(result.Text);
            }
        }
    }
}