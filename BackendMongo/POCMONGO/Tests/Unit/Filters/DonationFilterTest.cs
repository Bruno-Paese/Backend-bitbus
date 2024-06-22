using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCMONGO.Controllers.Filter;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace POCMONGO.Tests.Unit.Filters
{
    [TestClass]
    public class DonationFilterTest
    {
        [TestMethod]
        public void TestGetRegexOnNewFilter()
        {
            DonationFilter filter = new DonationFilter();
            Assert.IsNull(filter.GetFilterRegex(), "Expected GetFilterRegex to return null when no filters are set.");
        }

        [TestMethod]
        public void TestGetRegexOnFilterWithDonerName()
        {
            DonationFilter filter = new DonationFilter
            {
                DonerName = "John Doe"
            };

            Regex filterRegex = filter.GetFilterRegex();
            Debug.WriteLine(filterRegex.ToString());

            string expectedPattern = "(John Doe)";
            string resultPattern = filterRegex.ToString();

            Assert.AreEqual(expectedPattern, resultPattern, "Expected regex pattern does not match the result.");
        }

        [TestMethod]
        public void TestGetRegexOnFilterWithEndDate()
        {
            DonationFilter filter = new DonationFilter
            {
                EndDonationDate = "25/12/2020"
            };

            Regex filterRegex = filter.GetFilterRegex();
            Debug.WriteLine(filterRegex.ToString());

            string expectedPattern = "(25/12/2020)";
            string resultPattern = filterRegex.ToString();

            Assert.AreEqual(expectedPattern, resultPattern, "Expected regex pattern does not match the result." + expectedPattern + resultPattern);
        }

        [TestMethod]
        public void TestGetRegexOnFilterWithStartDate()
        {
            DonationFilter filter = new DonationFilter
            {
                StartDonationDate = "25/12/2020"
            };

            Regex filterRegex = filter.GetFilterRegex();
            Debug.WriteLine(filterRegex.ToString());

            string expectedPattern = "(25/12/2020)";
            string resultPattern = filterRegex.ToString();

            Assert.AreEqual(expectedPattern, resultPattern, "Expected regex pattern does not match the result." + expectedPattern + resultPattern);
        }

        [TestMethod]
        public void TestGetRegexOnFilterWithAllFields()
        {
            DonationFilter filter = new DonationFilter
            {
                DonerName = "Jane Doe",
                StartDonationDate = "01/01/2021",
                EndDonationDate = "31/12/2021"
            };

            Regex filterRegex = filter.GetFilterRegex();
            Debug.WriteLine(filterRegex.ToString());

            string expectedPattern = "(Jane Doe)(01/01/2021)(31/12/2021)";
            string resultPattern = filterRegex.ToString();

            Assert.AreEqual(expectedPattern, resultPattern, "Expected regex pattern does not match the result.");
        }
    }
}
