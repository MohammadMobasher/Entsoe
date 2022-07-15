using System.Xml.Serialization;

namespace Entsoe.Models.Result
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(AcknowledgementMarketDocument));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (AcknowledgementMarketDocument)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "sender_MarketParticipant.mRID")]
	public class SenderMarketParticipantMRID
	{

		[XmlAttribute(AttributeName = "codingScheme")]
		public string CodingScheme { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "receiver_MarketParticipant.mRID")]
	public class ReceiverMarketParticipantMRID
	{

		[XmlAttribute(AttributeName = "codingScheme")]
		public string CodingScheme { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Reason")]
	public class Reason
	{

		[XmlElement(ElementName = "code")]
		public int Code { get; set; }

		[XmlElement(ElementName = "text")]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Acknowledgement_MarketDocument")]
	public class AcknowledgementMarketDocument
	{

		[XmlElement(ElementName = "mRID")]
		public string MRID { get; set; }

		[XmlElement(ElementName = "createdDateTime")]
		public DateTime CreatedDateTime { get; set; }

		[XmlElement(ElementName = "sender_MarketParticipant.mRID")]
		public SenderMarketParticipantMRID SenderMarketParticipantMRID { get; set; }

		[XmlElement(ElementName = "sender_MarketParticipant.marketRole.type")]
		public string SenderMarketParticipantMarketRoleType { get; set; }

		[XmlElement(ElementName = "receiver_MarketParticipant.mRID")]
		public ReceiverMarketParticipantMRID ReceiverMarketParticipantMRID { get; set; }

		[XmlElement(ElementName = "receiver_MarketParticipant.marketRole.type")]
		public string ReceiverMarketParticipantMarketRoleType { get; set; }

		[XmlElement(ElementName = "received_MarketDocument.createdDateTime")]
		public DateTime ReceivedMarketDocumentCreatedDateTime { get; set; }

		[XmlElement(ElementName = "Reason")]
		public Reason Reason { get; set; }

		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }

		[XmlText]
		public string Text { get; set; }
	}


}
