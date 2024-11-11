﻿using System;
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

        /// <summary>
        /// The xml namespace for EDXL Common Types 1.0
        /// </summary>
        public static readonly XNamespace EdxlCt10Namespace = "urn:oasis:names:tc:emergency:edxl:ct:1.0";

        public static XElement ToXElement(this EdxlDistribution edxlDistribution)
        {
            var result = new XElement(EdxlDe20Namespace + "EDXLDistribution",
                new XAttribute(XNamespace.Xmlns + "ct", EdxlCt10Namespace),
                new XElement(EdxlDe20Namespace + "DistributionID", edxlDistribution.DistributionId),
                new XElement(EdxlDe20Namespace + "SenderID", edxlDistribution.SenderId),
                new XElement(EdxlDe20Namespace + "DateTimeSent", FormatDateForCap(edxlDistribution.DateTimeSent)),
                new XElement(EdxlDe20Namespace + "DateTimeExpires", FormatDateForCap(edxlDistribution.DateTimeExpires)),
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
            return new XElement(EdxlDe20Namespace + "DistributionStatus",
                distributionStatus.StatusKindDefault.ToXElement());
        }

        private static XElement ToXElement(this StatusKindDefault statusKindDefault)
        {
            return new XElement(EdxlDe20Namespace + "StatusKindDefault",
                new XElement(EdxlCt10Namespace + "ValueListURI",
                    statusKindDefault.ValueListUri),
                new XElement(EdxlCt10Namespace + "Value", statusKindDefault.Value));
        }

        private static XElement ToXElement(this DistributionKind distributionKind)
        {
            return new XElement(EdxlDe20Namespace + "DistributionKind",
                distributionKind.DistributionKindDefault.ToXElement());
        }

        private static XElement ToXElement(this DistributionKindDefault distributionKindDefault)
        {
            return new XElement(EdxlDe20Namespace + "DistributionKindDefault",
                new XElement(EdxlCt10Namespace + "ValueListURI",
                    distributionKindDefault.ValueListUri),
                new XElement(EdxlCt10Namespace + "Value", distributionKindDefault.Value));
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

        private static DateTimeOffset FormatDateForCap(DateTimeOffset date)
        {
            return date.AddMilliseconds(-date.Millisecond);
        }
    }
}
