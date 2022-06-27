using Xunit;
using Entsoe;
using System;

namespace EntsoeTest
{
    public class UnitTest1
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
    }
}