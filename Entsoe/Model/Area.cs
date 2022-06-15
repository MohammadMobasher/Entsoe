
namespace Entsoe.Model
{
    public static class Area
    {
        private static readonly List<AreaItem> AreaItems = new()
        {
            new AreaItem
            {
                CountryCode = "NL",
                Domain = "10YNL----------L",
                CountryName = "Netherlands, TenneT NL BZ / CA/ MBA",
                TimeZoneName = "Europe/Amsterdam"
            },

            new AreaItem
            {
                CountryCode = "BE",
                Domain = "10YBE----------2",
                CountryName = "Belgium, Elia BZ / CA / MBA",
                TimeZoneName = "Europe/Brussels"
            }
        };


        /// <summary>
        /// get an area base on countryCode
        /// </summary>
        /// <param name="countryCode">like NL</param>
        /// <returns></returns>
        public static AreaItem? GetArea(string countryCode) => AreaItems.SingleOrDefault(x => x.CountryCode.ToLower() == countryCode.ToLower());

    }


    public class AreaItem
    {

        public string CountryCode { get; set; }
        public string Domain { get; set; }
        public string CountryName { get; set; }

        public string TimeZoneName { get; set; }
        public TimeZoneInfo TimeZoneInfo
        {
            get
            {
                if (!string.IsNullOrEmpty(TimeZoneName))
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);
                }
                throw new Exception($"There is no TimeZoneInfo {TimeZoneName}");
            }
        }
    }
}
