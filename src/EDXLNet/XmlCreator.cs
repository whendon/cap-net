using System;
using System.Linq;
using System.Xml.Linq;
using EDXLNet.Models;

namespace EDXLNet
{
    public static class XmlCreator
    {
        /// <summary>
        /// The xml namespace for EDXL-DE 2.0
        /// </summary>
        public static readonly XNamespace EdxlDe20Namespace = "urn:oasis:names:tc:emergency:EDXL:DE:2.0";
        
        public static XElement ToXElement(this EdxlDistribution edxlDistribution)
        {
            var result = new XElement(EdxlDe20Namespace + "EDXLDistribution",
                new XElement(EdxlDe20Namespace + "DistributionID", edxlDistribution.DistributionId),
                new XElement(EdxlDe20Namespace + "SenderID", edxlDistribution.SenderId),
                new XElement(EdxlDe20Namespace + "DateTimeSent", StripMiliseconds(edxlDistribution.DateTimeSent)),
                new XElement(EdxlDe20Namespace + "DateTimeExpires", StripMiliseconds(edxlDistribution.DateTimeExpires)),
                edxlDistribution.DistributionStatus.ToXElement(),
                edxlDistribution.DistributionKind.ToXElement());

            if (edxlDistribution.Content != null)
            {
                result.Add(edxlDistribution.Content.ToXElement());
            }

            return result;
        }

        private static XElement ToXElement(this DistributionStatus distributionStatus)
        {
            return new XElement(EdxlDe20Namespace + "DistributionStatus");
        }

        private static XElement ToXElement(this DistributionKind distributionKind)
        {
            return new XElement(EdxlDe20Namespace + "DistributionKind");
        }

        private static XElement ToXElement(this Content content)
        {
            return new XElement(EdxlDe20Namespace + "Content",
                content.ContentObjects.Select(co => co.ToXElement()));
        }

        private static XElement ToXElement(this ContentObject contentObject)
        {
            return new XElement(EdxlDe20Namespace + "ContentObject",
                contentObject.ContentXml.ToXElement());
        }

        private static XElement ToXElement(this ContentXml contentXml)
        {
            return new XElement(EdxlDe20Namespace + "ContentXML",
                new XElement(EdxlDe20Namespace + "EmbeddedXMLContent", contentXml.EmbeddedXml));
        }

        private static DateTimeOffset StripMiliseconds(DateTimeOffset date)
        {
            return date.AddMilliseconds(-date.Millisecond);
        }
    }
}
