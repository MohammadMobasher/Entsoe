using Entsoe;
//using Microsoft.Extensions.Configuration;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using System;
//using System.Threading.Tasks;
using Xunit;

namespace EntsoeTest
{
    public class EntsoeClientUnitTest
    {
        //private EntsoeClient entsoeClient;


        //[SetUp]
        //public void Setup()
        //{
        //    var builder = new ConfigurationBuilder()
        //       .AddUserSecrets<EntsoeClientUnitTest>();

        //    var Configuration = builder.Build();
        //    string _apiKey = "";
        //    entsoeClient = new(_apiKey);
        //}


        [Fact]
        public void EmptyApiKey()
        {
            // ARRANGE
            bool hasArgumentNullException = false;

            // ACT
            try
            {
                EntsoeClient entsoeClient = new("");
            }
            catch (ArgumentNullException)
            {
                hasArgumentNullException = true;
            }

            // ASSERT
            Assert.True(hasArgumentNullException);
        }

        //[Fact]
        //public void QueryDayAheadPricesTest()
        //{
        //    EntsoeClient entsoeClient = new("");
            

        //}

        
    }
}