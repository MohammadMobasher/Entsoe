
using System.ComponentModel.DataAnnotations;

namespace Entsoe.Models
{
    /// <summary>
    /// List taken directly from the API Docs
    /// </summary>
    public enum Area
    {
        [AreaInfo(
            "DE_50HZ",
            "10YDE-VE-------2",
            "50Hertz CA, DE(50HzT) BZA",
            "Europe/Berlin"
        )]
        DE_50HZ,


        [AreaInfo(
            "AL",
            "10YAL-KESH-----5",
            "Albania, OST BZ / CA / MBA",
            "Europe/Tirane"
        )]
        AL,


    }

    //public static class Area
    //{
    //    /// <summary>
    //    /// List taken directly from the API Docs
    //    /// </summary>
    //    private static readonly List<AreaItem> AreaItems = new()
    //    {
    //        new AreaItem
    //        {
    //            CountryCode = "DE_50HZ",
    //            Domain = "10YDE-VE-------2",
    //            CountryName = "50Hertz CA, DE(50HzT) BZA",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "AL",
    //            Domain = "10YAL-KESH-----5",
    //            CountryName = "Albania, OST BZ / CA / MBA",
    //            TimeZoneName = "Europe/Tirane"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DE_AMPRION",
    //            Domain = "10YDE-RWENET---I",
    //            CountryName = "Amprion CA",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "AT",
    //            Domain = "10YAT-APG------L",
    //            CountryName = "Austria, APG BZ / CA / MBA",
    //            TimeZoneName = "Europe/Vienna"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "BY",
    //            Domain = "10Y1001A1001A51S",
    //            CountryName = "Belarus BZ / CA / MBA",
    //            TimeZoneName = "Europe/Minsk"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "BE",
    //            Domain = "10YBE----------2",
    //            CountryName = "Belgium, Elia BZ / CA / MBA",
    //            TimeZoneName = "Europe/Brussels"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "BA",
    //            Domain = "10YBA-JPCC-----D",
    //            CountryName = "Bosnia Herzegovina, NOS BiH BZ / CA / MBA",
    //            TimeZoneName = "Europe/Sarajevo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "BG",
    //            Domain = "10YCA-BULGARIA-R",
    //            CountryName = "Bulgaria, ESO BZ / CA / MBA",
    //            TimeZoneName = "Europe/Sofia"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "CZ_DE_SK",
    //            Domain = "10YDOM-CZ-DE-SKK",
    //            CountryName = "BZ CZ+DE+SK BZ / BZA",
    //            TimeZoneName = "Europe/Prague"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "HR",
    //            Domain = "10YHR-HEP------M",
    //            CountryName = "Croatia, HOPS BZ / CA / MBA",
    //            TimeZoneName = "Europe/Zagreb"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "CWE",
    //            Domain = "10YDOM-REGION-1V",
    //            CountryName = "CWE Region",
    //            TimeZoneName = "Europe/Brussels"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "CY",
    //            Domain = "10YCY-1001A0003J",
    //            CountryName = "Cyprus, Cyprus TSO BZ / CA / MBA",
    //            TimeZoneName = "Asia/Nicosia"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "CZ",
    //            Domain = "10YCZ-CEPS-----N",
    //            CountryName = "Czech Republic, CEPS BZ / CA/ MBA",
    //            TimeZoneName = "Europe/Prague"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DE_AT_LU",
    //            Domain = "10Y1001A1001A63L",
    //            CountryName = "DE-AT-LU BZ",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DE_LU",
    //            Domain = "10Y1001A1001A82H",
    //            CountryName = "DE-LU BZ / MBA",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DK",
    //            Domain = "10Y1001A1001A65H",
    //            CountryName = "Denmark",
    //            TimeZoneName = "Europe/Copenhagen"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DK_1",
    //            Domain = "10YDK-1--------W",
    //            CountryName = "DK1 BZ / MBA",
    //            TimeZoneName = "Europe/Copenhagen"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DK_2",
    //            Domain = "10YDK-2--------M",
    //            CountryName = "DK2 BZ / MBA",
    //            TimeZoneName = "Europe/Copenhagen"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DK_CA",
    //            Domain = "10Y1001A1001A796",
    //            CountryName = "Denmark, Energinet CA",
    //            TimeZoneName = "Europe/Copenhagen"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "EE",
    //            Domain = "10Y1001A1001A39I",
    //            CountryName = "Estonia, Elering BZ / CA / MBA",
    //            TimeZoneName = "Europe/Tallinn"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "FI",
    //            Domain = "10YFI-1--------U",
    //            CountryName = "Finland, Fingrid BZ / CA / MBA",
    //            TimeZoneName = "Europe/Helsinki"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "MK",
    //            Domain = "10YMK-MEPSO----8",
    //            CountryName = "Former Yugoslav Republic of Macedonia, MEPSO BZ / CA / MBA",
    //            TimeZoneName = "Europe/Skopje"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "FR",
    //            Domain = "10YFR-RTE------C",
    //            CountryName = "France, RTE BZ / CA / MBA",
    //            TimeZoneName = "Europe/Paris"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DE",
    //            Domain = "10Y1001A1001A83F",
    //            CountryName = "Germany",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "GR",
    //            Domain = "10YGR-HTSO-----Y",
    //            CountryName = "Greece, IPTO BZ / CA/ MBA",
    //            TimeZoneName = "Europe/Athens"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "HU",
    //            Domain = "10YHU-MAVIR----U",
    //            CountryName = "Hungary, MAVIR CA / BZ / MBA",
    //            TimeZoneName = "Europe/Budapest"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IS",
    //            Domain = "IS",
    //            CountryName = "celand",
    //            TimeZoneName = "Atlantic/Reykjavik"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IE_SEM",
    //            Domain = "10Y1001A1001A59C",
    //            CountryName = "Ireland (SEM) BZ / MBA",
    //            TimeZoneName = "Europe/Dublin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IE",
    //            Domain = "10YIE-1001A00010",
    //            CountryName = "Ireland, EirGrid CA",
    //            TimeZoneName = "Europe/Dublin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT",
    //            Domain = "10YIT-GRTN-----B",
    //            CountryName = "Italy, IT CA / MBA",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_SACO_AC",
    //            Domain = "10Y1001A1001A885",
    //            CountryName = "Italy_Saco_AC",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_CALA",
    //            Domain = "10Y1001C--00096J",
    //            CountryName = "IT-Calabria BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_SACO_DC",
    //            Domain = "10Y1001A1001A893",
    //            CountryName = "Italy_Saco_DC",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_BRNN",
    //            Domain = "10Y1001A1001A699",
    //            CountryName = "IT-Brindisi BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_CNOR",
    //            Domain = "10Y1001A1001A70O",
    //            CountryName = "IT-Centre-North BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_CSUD",
    //            Domain = "10Y1001A1001A71M",
    //            CountryName = "IT-Centre-South BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_FOGN",
    //            Domain = "10Y1001A1001A72K",
    //            CountryName = "IT-Foggia BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_GR",
    //            Domain = "10Y1001A1001A66F",
    //            CountryName = "IT-GR BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_MACRO_NORTH",
    //            Domain = "10Y1001A1001A84",
    //            CountryName = "IT-MACROZONE NORTH MBA",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_MACRO_SOUTH",
    //            Domain = "10Y1001A1001A85",
    //            CountryName = "IT-MACROZONE SOUTH MBA",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_MALTA",
    //            Domain = "10Y1001A1001A877",
    //            CountryName = "IT-Malta BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_NORD",
    //            Domain = "10Y1001A1001A73I",
    //            CountryName = "IT-North BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_NORD_AT",
    //            Domain = "10Y1001A1001A80L",
    //            CountryName = "IT-North-AT BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_NORD_CH",
    //            Domain = "10Y1001A1001A68B",
    //            CountryName = "IT-North-CH BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_NORD_FR",
    //            Domain = "10Y1001A1001A81J",
    //            CountryName = "IT-North-FR BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_NORD_SI",
    //            Domain = "10Y1001A1001A67D",
    //            CountryName = "IT-North-SI BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_PRGP",
    //            Domain = "10Y1001A1001A76C",
    //            CountryName = "IT-Priolo BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_ROSN",
    //            Domain = "10Y1001A1001A77A",
    //            CountryName = "IT-Rossano BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_SARD",
    //            Domain = "10Y1001A1001A74G",
    //            CountryName = "IT-Sardinia BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_SICI",
    //            Domain = "10Y1001A1001A75E",
    //            CountryName = "IT-Sicily BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "IT_SUD",
    //            Domain = "10Y1001A1001A788",
    //            CountryName = "IT-South BZ",
    //            TimeZoneName = "Europe/Rome"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "RU_KGD",
    //            Domain = "10Y1001A1001A50U",
    //            CountryName = "Kaliningrad BZ / CA / MBA",
    //            TimeZoneName = "Europe/Kaliningrad"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "LV",
    //            Domain = "10YLV-1001A00074",
    //            CountryName = "Latvia, AST BZ / CA / MBA",
    //            TimeZoneName = "Europe/Riga"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "LT",
    //            Domain = "10YLT-1001A0008Q",
    //            CountryName = "Lithuania, Litgrid BZ / CA / MBA",
    //            TimeZoneName = "Europe/Vilnius"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "LU",
    //            Domain = "10YLU-CEGEDEL-NQ",
    //            CountryName = "Luxembourg, CREOS CA",
    //            TimeZoneName = "Europe/Luxembourg"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "MT",
    //            Domain = "10Y1001A1001A93C",
    //            CountryName = "Malta, Malta BZ / CA / MBA",
    //            TimeZoneName = "Europe/Malta"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "ME",
    //            Domain = "10YCS-CG-TSO---S",
    //            CountryName = "Montenegro, CGES BZ / CA / MBA",
    //            TimeZoneName = "Europe/Podgorica"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "GB",
    //            Domain = "10YGB----------A",
    //            CountryName = "National Grid BZ / CA/ MBA",
    //            TimeZoneName = "Europe/London"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "GB_IFA",
    //            Domain = "10Y1001C--00098F",
    //            CountryName = "GB(IFA) BZN",
    //            TimeZoneName = "Europe/London"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "GB_IFA2",
    //            Domain = "17Y0000009369493",
    //            CountryName = "GB(IFA2) BZ",
    //            TimeZoneName = "Europe/London"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "GB_ELECLINK",
    //            Domain = "11Y0-0000-0265-K",
    //            CountryName = "GB(ElecLink) BZN",
    //            TimeZoneName = "Europe/London"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "UK",
    //            Domain = "10Y1001A1001A92E",
    //            CountryName = "United Kingdom",
    //            TimeZoneName = "Europe/London"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NL",
    //            Domain = "10YNL----------L",
    //            CountryName = "Netherlands, TenneT NL BZ / CA/ MBA",
    //            TimeZoneName = "Europe/Amsterdam"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO_1",
    //            Domain = "10YNO-1--------2",
    //            CountryName = "NO1 BZ / MBA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO_2",
    //            Domain = "10YNO-2--------T",
    //            CountryName = "NO2 BZ / MBA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO_2_NSL",
    //            Domain = "50Y0JVU59B4JWQCU",
    //            CountryName = "NO2 NSL BZ / MBA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO_3",
    //            Domain = "10YNO-3--------J",
    //            CountryName = "NO3 BZ / MBA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO_4",
    //            Domain = "10YNO-4--------9",
    //            CountryName = "NO4 BZ / MBA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO_5",
    //            Domain = "10Y1001A1001A48H",
    //            CountryName = "NO5 BZ / MBA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "NO",
    //            Domain = "10YNO-0--------C",
    //            CountryName = "Norway, Norway MBA, Stattnet CA",
    //            TimeZoneName = "Europe/Oslo"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "PL_CZ",
    //            Domain = "10YDOM-1001A082L",
    //            CountryName = "PL-CZ BZA / CA",
    //            TimeZoneName = "Europe/Warsaw"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "PL",
    //            Domain = "10YPL-AREA-----S",
    //            CountryName = "Poland, PSE SA BZ / BZA / CA / MBA",
    //            TimeZoneName = "Europe/Warsaw"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "PT",
    //            Domain = "10YPT-REN------W",
    //            CountryName = "Portugal, REN BZ / CA / MBA",
    //            TimeZoneName = "Europe/Lisbon"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "MD",
    //            Domain = "10Y1001A1001A990",
    //            CountryName = "Republic of Moldova, Moldelectica BZ/CA/MBA",
    //            TimeZoneName = "Europe/Chisinau"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "RO",
    //            Domain = "10YRO-TEL------P",
    //            CountryName = "Romania, Transelectrica BZ / CA/ MBA",
    //            TimeZoneName = "Europe/Bucharest"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "RU",
    //            Domain = "10Y1001A1001A49F",
    //            CountryName = "Russia BZ / CA / MBA",
    //            TimeZoneName = "Europe/Moscow"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SE_1",
    //            Domain = "10Y1001A1001A44P",
    //            CountryName = "SE1 BZ / MBA",
    //            TimeZoneName = "Europe/Stockholm"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SE_2",
    //            Domain = "10Y1001A1001A45N",
    //            CountryName = "SE2 BZ / MBA",
    //            TimeZoneName = "Europe/Stockholm"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SE_3",
    //            Domain = "10Y1001A1001A46L",
    //            CountryName = "SE3 BZ / MBA",
    //            TimeZoneName = "Europe/Stockholm"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SE_4",
    //            Domain = "10Y1001A1001A47J",
    //            CountryName = "SE4 BZ / MBA",
    //            TimeZoneName = "Europe/Stockholm"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "RS",
    //            Domain = "10YCS-SERBIATSOV",
    //            CountryName = "Serbia, EMS BZ / CA / MBA",
    //            TimeZoneName = "Europe/Belgrade"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SK",
    //            Domain = "10YSK-SEPS-----K",
    //            CountryName = "Slovakia, SEPS BZ / CA / MBA",
    //            TimeZoneName = "Europe/Bratislava"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SI",
    //            Domain = "10YSI-ELES-----O",
    //            CountryName = "Slovenia, ELES BZ / CA / MBA",
    //            TimeZoneName = "Europe/Ljubljana"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "GB_NIR",
    //            Domain = "10Y1001A1001A016",
    //            CountryName = "Northern Ireland, SONI CA",
    //            TimeZoneName = "Europe/Belfast"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "ES",
    //            Domain = "10YES-REE------0",
    //            CountryName = "Spain, REE BZ / CA / MBA",
    //            TimeZoneName = "Europe/Madrid"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "SE",
    //            Domain = "10YSE-1--------K",
    //            CountryName = "Sweden, Sweden MBA, SvK CA",
    //            TimeZoneName = "Europe/Stockholm"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "CH",
    //            Domain = "10YCH-SWISSGRIDZ",
    //            CountryName = "Switzerland, Swissgrid BZ / CA / MBA",
    //            TimeZoneName = "Europe/Zurich"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DE_TENNET",
    //            Domain = "10YDE-EON------1",
    //            CountryName = "TenneT GER CA",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "DE_TRANSNET",
    //            Domain = "10YDE-ENBW-----N",
    //            CountryName = "TransnetBW CA",
    //            TimeZoneName = "Europe/Berlin"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "TR",
    //            Domain = "10YTR-TEIAS----W",
    //            CountryName = "Turkey BZ / CA / MBA",
    //            TimeZoneName = "Europe/Istanbul"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "UA",
    //            Domain = "10Y1001C--00003F",
    //            CountryName = "Ukraine, Ukraine BZ, MBA",
    //            TimeZoneName = "Europe/Kiev"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "UA_DOBTPP",
    //            Domain = "10Y1001A1001A869",
    //            CountryName = "Ukraine-DobTPP CTA",
    //            TimeZoneName = "Europe/Kiev"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "UA_BEI",
    //            Domain = "10YUA-WEPS-----0",
    //            CountryName = "Ukraine BEI CTA",
    //            TimeZoneName = "Europe/Kiev"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "UA_IPS",
    //            Domain = "10Y1001C--000182",
    //            CountryName = "Ukraine IPS CTA",
    //            TimeZoneName = "Europe/Kiev"
    //        },
    //        new AreaItem
    //        {
    //            CountryCode = "XK",
    //            Domain = "10Y1001C--00100H",
    //            CountryName = "Kosovo/ XK CA / XK BZN",
    //            TimeZoneName = "Europe/Rome"
    //        }
    //    };



    //    /// <summary>
    //    /// get an area base on countryCode
    //    /// </summary>
    //    /// <param name="countryCode"></param>
    //    /// <returns></returns>
    //    public static AreaItem? GetArea(string countryCode) => AreaItems.SingleOrDefault(x => x.CountryCode.ToLower() == countryCode.ToLower());

    //}

    ///// <summary>
    ///// each area info
    ///// </summary>
    //public class AreaItem
    //{

    //    /// <summary>
    //    /// CountryCode
    //    /// </summary>
    //    public string CountryCode { get; set; } = String.Empty;

    //    /// <summary>
    //    /// Domain
    //    /// </summary>
    //    public string Domain { get; set; } = String.Empty;

    //    /// <summary>
    //    /// CountryName
    //    /// </summary>
    //    public string CountryName { get; set; } = String.Empty;

    //    /// <summary>
    //    /// TimeZoneName
    //    /// </summary>
    //    public string TimeZoneName { get; set; } = String.Empty;

    //    /// <summary>
    //    /// TimeZoneInfo
    //    /// </summary>
    //    public TimeZoneInfo TimeZoneInfo
    //    {
    //        get
    //        {
    //            if (!string.IsNullOrEmpty(TimeZoneName))
    //            {
    //                return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);
    //            }
    //            throw new Exception($"There is no TimeZoneInfo {TimeZoneName}");
    //        }
    //    }
    //}
}
