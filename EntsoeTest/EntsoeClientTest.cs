using Xunit;
using Entsoe;
using System;

namespace EntsoeTest
{
    public class EntsoeClientTest
    {
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


        [Fact]
        public void QueryDayAheadPricesTest()
        {
            EntsoeClient entsoeClient = new("");


        }


    }
}