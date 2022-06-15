namespace Entsoe.Models
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AreaInfoAttribute : Attribute
    {

        public string CountryCode { get; set; }

        public string Domain { get; set; }

        public string CountryName { get; set; }

        public string TimeZoneName { get; set; }


        public AreaInfoAttribute(
            string countryCode,
            string domain,
            string countryName,
            string timeZoneName
        )
        {
            CountryCode = countryCode;
            Domain = domain;
            CountryCode = countryName;
            TimeZoneName = timeZoneName;
        }

        public string GetCountryCode()
        {
            return CountryCode;
        }

        public string GetDomain()
        {
            return Domain;
        }


        public string GetCountryName()
        {
            return CountryName;
        }


        public string GetTimeZoneName()
        {
            return TimeZoneName;
        }


        public TimeZoneInfo GetTimeZoneInfo()
        {
            if (!string.IsNullOrEmpty(TimeZoneName))
            {
                return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);
            }
            throw new Exception($"There is no TimeZoneInfo {TimeZoneName}");
        }

    }
}
