using Entsoe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace EntsoeTest
{
    [TestClass]
    public class EntsoeClientUnitTest
    {
        [TestMethod]
        public void EmptyApiKey()
        {
            bool hasArgumentNullException = false;
            try
            {
                EntsoeClient entsoeClient = new("");
            }
            catch (ArgumentNullException)
            {
                hasArgumentNullException = true;
            }

            Assert.AreEqual(hasArgumentNullException, true);

        }

        [TestMethod]
        public void QueryDayAheadPricesTest()
        {
            EntsoeClient entsoeClient = new("");
            

        }

        
    }
}