using Xunit;
using Entsoe;
using System;
using Microsoft.Extensions.Configuration;
using Entsoe.Models;
using System.Threading.Tasks;

namespace EntsoeTest
{
    public class EntsoeClientTest
    {
        private string _apiKey { get; set; }
        private EntsoeClient entsoeClient { get; set; }

        public EntsoeClientTest()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<Setting>().Build();

            _apiKey = configuration.GetSection("ApiKey").Value;

            entsoeClient = new(_apiKey);
        }


        [Fact]
        public void EmptyApiKeyTest()
        {
            // ARRANGE
            bool hasArgumentNullException = false;

            // ACT
            try
            {
                EntsoeClient entsoeClient = new(string.Empty);
            }
            catch (ArgumentNullException)
            {
                hasArgumentNullException = true;
            }

            // ASSERT
            Assert.True(hasArgumentNullException);
        }


        [Fact]
        public async Task QueryDayAheadPricesRejectionRequestTest()
        {

            // ARRANGE
            Area area = Area.AL;
            DateTime start = new(2021, 01, 01, 12, 0, 0, DateTimeKind.Utc);
            DateTime end = new(2021, 01, 02, 12, 0, 0, DateTimeKind.Utc);

            // ACT + ASSERT
            await Assert.ThrowsAsync<Exception>(() => (entsoeClient.QueryDayAheadPrices(area, start, end)));
        }


    }
}