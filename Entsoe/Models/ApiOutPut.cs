/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System.Xml.Serialization;

namespace Entsoe.Models
{
    
    [XmlRoot(ElementName = "period.timeInterval", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
    public class PeriodTimeInterval
    {
        [XmlElement(ElementName = "start", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Start { get; set; }
        [XmlElement(ElementName = "end", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string End { get; set; }
    }

    [XmlRoot(ElementName = "timeInterval", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
    public class TimeInterval
    {
        [XmlElement(ElementName = "start", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Start { get; set; }
        [XmlElement(ElementName = "end", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string End { get; set; }
    }

    [XmlRoot(ElementName = "Point", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
    public class Point
    {
        [XmlElement(ElementName = "position", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Position { get; set; }
        [XmlElement(ElementName = "procurement_Price.amount", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Procurement_Price_amount { get; set; }
        [XmlElement(ElementName = "imbalance_Price.category", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Imbalance_Price_category { get; set; }
    }

    [XmlRoot(ElementName = "Period", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
    public class Period
    {
        [XmlElement(ElementName = "timeInterval", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public TimeInterval TimeInterval { get; set; }
        [XmlElement(ElementName = "resolution", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Resolution { get; set; }
        [XmlElement(ElementName = "Point", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public Point Point { get; set; }
    }

    [XmlRoot(ElementName = "TimeSeries", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
    public class TimeSeries
    {
        [XmlElement(ElementName = "mRID", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string MRID { get; set; }
        [XmlElement(ElementName = "businessType", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string BusinessType { get; set; }
        [XmlElement(ElementName = "type_MarketAgreement.type", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Type_MarketAgreement_type { get; set; }
        [XmlElement(ElementName = "mktPSRType.psrType", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string MktPSRType_psrType { get; set; }
        [XmlElement(ElementName = "flowDirection.direction", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string FlowDirection_direction { get; set; }
        [XmlElement(ElementName = "currency_Unit.name", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Currency_Unit_name { get; set; }
        [XmlElement(ElementName = "quantity_Measure_Unit.name", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string Quantity_Measure_Unit_name { get; set; }
        [XmlElement(ElementName = "curveType", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public string CurveType { get; set; }
        [XmlElement(ElementName = "Period", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public Period Period { get; set; }
    }

    [XmlRoot(ElementName = "Balancing_MarketDocument", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
    public class BalancingMarketDocument
    {
        public PeriodTimeInterval Period_timeInterval { get; set; }
        [XmlElement(ElementName = "TimeSeries", Namespace = "urn:iec62325.351:tc57wg16:451-6:balancingdocument:3:0")]
        public List<TimeSeries> TimeSeries { get; set; }
    }

}
