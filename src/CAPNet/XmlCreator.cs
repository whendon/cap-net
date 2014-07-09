using System.Linq;
using System.Xml.Linq;

using CAPNet.Models;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace CAPNet
{
    /// <summary>
    /// Class that converts an alert to its XML representation
    /// </summary>
    public static class XmlCreator
    {
        /// <summary>
        /// The xml namespace for CAP 1.1
        /// </summary>
        public static readonly XNamespace CAP11Namespace = "urn:oasis:names:tc:emergency:cap:1.1";

        /// <summary>
        /// The xml namespace for CAP 1.2
        /// </summary>
        public static readonly XNamespace CAP12Namespace = "urn:oasis:names:tc:emergency:cap:1.2";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alerts"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> Create(IEnumerable<Alert> alerts)
        {
            return from alert in alerts
                   select Create(alert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static XElement Create(Alert alert)
        {
            var alertElement = new XElement(CAP12Namespace + "alert");

            AddElementIfHasContent(alertElement, "identifier", alert.Identifier);
            AddElementIfHasContent(alertElement, "sender", alert.Sender);
            // set milliseconds to 0
            AddElementIfHasContent(alertElement, "sent", AddMilliseconds(alert.Sent));
            AddElementIfHasContent(alertElement, "status", alert.Status);
            AddElementIfHasContent(alertElement, "msgType", alert.MessageType);
            AddElementIfHasContent(alertElement, "source", alert.Source);
            AddElementIfHasContent(alertElement, "scope", alert.Scope);
            AddElementIfHasContent(alertElement, "restriction", alert.Restriction);
            string addressesContent = alert.Addresses.ToString();
            AddElementIfHasContent(alertElement, "addresses", addressesContent);
            AddElementIfHasContent(alertElement, "code", alert.Code);
            AddElementIfHasContent(alertElement, "note", alert.Note);
            AddElementIfHasContent(alertElement, "references", alert.References);
            string incidentsContent = alert.Incidents.ElementsDelimitedBySpace();
            AddElementIfHasContent(alertElement, "incidents", incidentsContent);
            AddElements(alertElement, Create(alert.Info));

            return alertElement;
        }

        private static DateTimeOffset AddMilliseconds(DateTimeOffset? date)
        {
            return date.Value.AddMilliseconds(-date.Value.Millisecond);
        }

        private static IEnumerable<XElement> Create(IEnumerable<Info> infos)
        {
            var infoElements =
                from info in infos
                select Create(info);

            return infoElements;
        }

        private static XElement Create(Info info)
        {
            var infoElement = new XElement(CAP12Namespace + "info");
            if (!info.Language.Equals(info.DefaultLanguage))
                infoElement.Add(new XElement(CAP12Namespace + "language", info.Language));
            infoElement.Add(info.Categories.Select(cat => new XElement(CAP12Namespace + "category", cat)));
            AddElementIfHasContent(infoElement, "event", info.Event);
            infoElement.Add(info.ResponseTypes.Select(res => new XElement(CAP12Namespace + "responseType", res)));
            AddElementIfHasContent(infoElement, "urgency", info.Urgency);
            AddElementIfHasContent(infoElement, "severity", info.Severity);
            AddElementIfHasContent(infoElement, "certainty", info.Certainty);
            AddElementIfHasContent(infoElement, "audience", info.Audience);
            AddElements(infoElement, Create(info.EventCodes));
            AddElementIfHasContent(infoElement, "effective", info.Effective);
            AddElementIfHasContent(infoElement, "onset", info.Onset);
            AddElementIfHasContent(infoElement, "expires", info.Expires);
            AddElementIfHasContent(infoElement, "senderName", info.SenderName);
            AddElementIfHasContent(infoElement, "headline", info.Headline);
            AddElementIfHasContent(infoElement, "description", info.Description);
            AddElementIfHasContent(infoElement, "instruction", info.Instruction);
            AddElementIfHasContent(infoElement, "web", info.Web);
            AddElementIfHasContent(infoElement, "contact", info.Contact);
            AddElements(infoElement, Create(info.Parameters));
            AddElements(infoElement, Create(info.Resources));
            AddElements(infoElement, Create(info.Areas));

            return infoElement;
        }

        private static IEnumerable<XElement> Create(IEnumerable<EventCode> codes)
        {
            var eventCodesElements =
                from e in codes
                select new XElement(
                    CAP12Namespace + "eventCode",
                    new XElement(CAP12Namespace + "valueName", e.ValueName),
                    new XElement(CAP12Namespace + "value", e.Value));

            return eventCodesElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<Parameter> parameters)
        {
            var parameterElements =
                from parameter in parameters
                select new XElement(
                    CAP12Namespace + "parameter",
                    new XElement(CAP12Namespace + "valueName", parameter.ValueName),
                    new XElement(CAP12Namespace + "value", parameter.Value));

            return parameterElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<Resource> resources)
        {
            var resourceElements =
                from resource in resources
                select Create(resource);

            return resourceElements;
        }

        private static XElement Create(Resource resource)
        {
            var resourceElement = new XElement(CAP12Namespace + "resource");

            AddElementIfHasContent(resourceElement, "resourceDesc", resource.Description);
            AddElementIfHasContent(resourceElement, "mimeType", resource.MimeType);
            AddElementIfHasContent(resourceElement, "size", resource.Size);
            AddElementIfHasContent(resourceElement, "uri", resource.Uri);
            AddElementIfHasContent(resourceElement, "derefUri", resource.DereferencedUri);
            AddElementIfHasContent(resourceElement, "digest", resource.Digest);

            return resourceElement;
        }

        private static IEnumerable<XElement> Create(IEnumerable<GeoCode> geoCodes)
        {
            var geoCodeElements =
                from geoCode in geoCodes
                select new XElement(
                    CAP12Namespace + "geocode",
                    new XElement(CAP12Namespace + "valueName", geoCode.ValueName),
                    new XElement(CAP12Namespace + "value", geoCode.Value));

            return geoCodeElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<Area> areas)
        {
            var areaElements =
                from area in areas
                select Create(area);

            return areaElements;
        }

        private static XElement Create(Area area)
        {
            var areaElement = new XElement(
                CAP12Namespace + "area",
                new XElement(CAP12Namespace + "areaDesc", area.Description),

                from polygon in area.Polygons
                select new XElement(
                    CAP12Namespace + "polygon", polygon),

                from circle in area.Circles
                select new XElement(
                    CAP12Namespace + "circle", circle),

                Create(area.GeoCodes));

            AddElementIfHasContent(areaElement, "altitude", area.Altitude);
            AddElementIfHasContent(areaElement, "ceiling", area.Ceiling);

            return areaElement;
        }

        private static void AddElementIfHasContent(XElement parent, string name, byte[] content)
        {
            if (content != null)
            {
                string base64DerefUri = Convert.ToBase64String(content);
                parent.Add(new XElement(CAP12Namespace + name, base64DerefUri));
            }
        }

        private static void AddElementIfHasContent<T>(XElement element, string name, T content)
        {
            if (content != null)
                element.Add(new XElement(CAP12Namespace + name, content));
        }

        private static void AddElements(XElement parent, IEnumerable<XElement> elements)
        {
            foreach (XElement element in elements)
                parent.Add(element);
        }

        private static void AddElementIfHasContent(XElement element, string name, string content)
        {
            if (!string.IsNullOrEmpty(content))
                element.Add(new XElement(CAP12Namespace + name, content));
        }

    }
}