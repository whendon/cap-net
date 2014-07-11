using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IEnumerable<Alert> Parse(string xml)
        {
            var document = XDocument.Parse(xml);
            var alertList = ParseInternal(document);

            return alertList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IEnumerable<Alert> Parse(XDocument xml)
        {
            var alertList = ParseInternal(xml);

            return alertList;
        }

        private static IEnumerable<Alert> ParseInternal(XDocument xdoc)
        {
            var elements = xdoc.Descendants(XmlCreator.CAP12Namespace + "alert");
            if (!elements.Any())
            {
                elements = xdoc.Descendants(XmlCreator.CAP11Namespace + "alert");
            }

            return from alertElement in elements
                   select ParseAlert(alertElement);
        }

        private static Alert ParseAlert(XElement alertElement)
        {
            var alert = new Alert();
            var capNamespace = alertElement.Name.Namespace;

            var infoNodes = alertElement.Elements(capNamespace + "info");
            var infos = from info in infoNodes
                        where info != null
                        select ParseInfo(info);

            alert.Info.AddRange(infos);

            var incidentsNode = alertElement.Element(capNamespace + "incidents");
            if (incidentsNode != null)
            {
                var incidentsNodeValue = incidentsNode.Value.Trim();
                if (!string.IsNullOrEmpty(incidentsNodeValue))
                {
                    var addresses = incidentsNodeValue.GetElements();
                    alert.Incidents.AddRange(addresses);
                }
            }

            var referencesNode = alertElement.Element(capNamespace + "references");
            if (referencesNode != null)
            {
                alert.References = referencesNode.Value;
            }

            var noteNode = alertElement.Element(capNamespace + "note");
            if (noteNode != null)
            {
                alert.Note = noteNode.Value;
            }

            var codeNode = alertElement.Element(capNamespace + "code");
            if (codeNode != null)
            {
                alert.Code = codeNode.Value;
            }

            var addressesNode = alertElement.Element(capNamespace + "addresses");
            if (addressesNode != null)
            {
                var addressNodeValue = addressesNode.Value.Trim();
                if (!string.IsNullOrEmpty(addressNodeValue))
                {
                    var addresses = addressNodeValue.GetElements();
                    alert.Addresses.AddRange(addresses);
                }
            }

            var restrictionNode = alertElement.Element(capNamespace + "restriction");
            if (restrictionNode != null)
            {
                alert.Restriction = restrictionNode.Value;
            }

            var scopeNode = alertElement.Element(capNamespace + "scope");
            if (scopeNode != null)
            {
                alert.Scope = EnumParse<Scope>(scopeNode.Value);
            }

            var sourceNode = alertElement.Element(capNamespace + "source");
            if (sourceNode != null)
            {
                alert.Source = sourceNode.Value;
            }

            var msgTypeNode = alertElement.Element(capNamespace + "msgType");
            if (msgTypeNode != null)
            {
                alert.MessageType = EnumParse<MessageType>(msgTypeNode.Value);
            }

            var statusNode = alertElement.Element(capNamespace + "status");
            if (statusNode != null)
            {
                alert.Status = EnumParse<Status>(statusNode.Value);
            }

            var sentNode = alertElement.Element(capNamespace + "sent");
            if (sentNode != null)
            {
                alert.Sent = TryParseDateTime(sentNode.Value);
            }

            var senderNode = alertElement.Element(capNamespace + "sender");
            if (senderNode != null)
            {
                alert.Sender = senderNode.Value;
            }

            var identifierNode = alertElement.Element(capNamespace + "identifier");
            if (identifierNode != null)
            {
                alert.Identifier = identifierNode.Value;
            }

            return alert;
        }

        private static T EnumParse<T>(string nodeValue)
        {
            return (T)Enum.Parse(typeof(T), nodeValue, true);
        }

        private static Info ParseInfo(XElement infoElement)
        {
            var info = new Info();

            var capNamespace = infoElement.Name.Namespace;

            var languageNode = infoElement.Element(capNamespace + "language");
            if (languageNode != null)
                info.Language = languageNode.Value;

            var categoryNodes = infoElement.Elements(capNamespace + "category");
            var categories = from categoryNode in categoryNodes
                             where categoryNode != null
                             select EnumParse<Category>(categoryNode.Value);

            info.Categories.AddRange(categories);

            var eventNode = infoElement.Element(capNamespace + "event");
            if (eventNode != null)
            {
                info.Event = eventNode.Value;
            }

            var responseTypeNodes = infoElement.Elements(capNamespace + "responseType");
            var responseTypes = from responseTypeNode in responseTypeNodes
                                where responseTypeNode != null
                                select EnumParse<ResponseType>(responseTypeNode.Value);

            info.ResponseTypes.AddRange(responseTypes);

            var urgencyNode = infoElement.Element(capNamespace + "urgency");
            if (urgencyNode != null)
            {
                info.Urgency = EnumParse<Urgency>(urgencyNode.Value);
            }

            var certaintyNode = infoElement.Element(capNamespace + "certainty");
            if (certaintyNode != null)
            {
                if (certaintyNode.Value == "Very Likely")
                {
                    info.Certainty = Certainty.Likely;
                }
                else
                {
                    info.Certainty = EnumParse<Certainty>(certaintyNode.Value);
                }
            }

            var audienceNode = infoElement.Element(capNamespace + "audience");
            if (audienceNode != null)
            {
                info.Audience = audienceNode.Value;
            }

            var eventCodeNodes = infoElement.Elements(capNamespace + "eventCode");
            var eventCodes = from ev in eventCodeNodes
                             where ev != null
                             let value = ev.Element(capNamespace + "value").Value
                             let valueName = ev.Element(capNamespace + "valueName").Value
                             select new EventCode(valueName, value);

            info.EventCodes.AddRange(eventCodes);

            var effectiveNode = infoElement.Element(capNamespace + "effective");
            if (effectiveNode != null)
            {
                info.Effective = TryParseDateTime(effectiveNode.Value);
            }

            var severityNode = infoElement.Element(capNamespace + "severity");
            if (severityNode != null)
            {
                info.Severity = EnumParse<Severity>(severityNode.Value);
            }

            var onsetNode = infoElement.Element(capNamespace + "onset");
            if (onsetNode != null)
            {
                info.Onset = TryParseDateTime(onsetNode.Value);
            }

            var expiresNode = infoElement.Element(capNamespace + "expires");
            if (expiresNode != null)
            {
                info.Expires = TryParseDateTime(expiresNode.Value);
            }

            var senderNameNode = infoElement.Element(capNamespace + "senderName");
            if (senderNameNode != null)
            {
                info.SenderName = senderNameNode.Value;
            }

            var headlineNode = infoElement.Element(capNamespace + "headline");
            if (headlineNode != null)
            {
                info.Headline = headlineNode.Value;
            }

            var descriptionNode = infoElement.Element(capNamespace + "description");
            if (descriptionNode != null)
            {
                info.Description = descriptionNode.Value;
            }

            var instructionNode = infoElement.Element(capNamespace + "instruction");
            if (instructionNode != null)
            {
                info.Instruction = instructionNode.Value;
            }

            var webNode = infoElement.Element(capNamespace + "web");
            if (webNode != null)
            {
                info.Web = new Uri(webNode.Value);
            }

            var contactNode = infoElement.Element(capNamespace + "contact");
            if (contactNode != null)
            {
                info.Contact = contactNode.Value;
            }

            var parameterNodes = infoElement.Elements(capNamespace + "parameter");
            var parameters = from parameter in parameterNodes
                             let valueNameNode = parameter.Element(capNamespace + "valueName")
                             let valueNode = parameter.Element(capNamespace + "value")
                             where valueNameNode != null && valueNode != null
                             select new Parameter(valueNameNode.Value, valueNode.Value);

            info.Parameters.AddRange(parameters);

            var resourceNodes = infoElement.Elements(capNamespace + "resource");
            var resources = from resourceNode in resourceNodes
                            where resourceNode != null
                            select ParseResource(resourceNode);

            info.Resources.AddRange(resources);

            var areaNodes = infoElement.Elements(capNamespace + "area");
            var areas = from areaNode in areaNodes
                        where areaNode != null
                        select ParseArea(areaNode);

            info.Areas.AddRange(areas);

            return info;
        }

        private static Area ParseArea(XElement areaElement)
        {
            var area = new Area();

            var capNamespace = areaElement.Name.Namespace;

            var areaDescNode = areaElement.Element(capNamespace + "areaDesc");
            if (areaDescNode != null)
                area.Description = areaDescNode.Value;

            var polygons = from polygonNode in areaElement.Elements(capNamespace + "polygon")
                           where polygonNode != null
                           select new Polygon(polygonNode.Value);

            area.Polygons.AddRange(polygons);

            var circleNodes = areaElement.Elements(capNamespace + "circle");
            var circles = from circleNode in circleNodes
                          where circleNode != null
                          select new Circle(circleNode.Value);

            area.Circles.AddRange(circles);

            var geoCodeNodes = areaElement.Elements(capNamespace + "geocode");
            var geoCodes = from geoCodeNode in geoCodeNodes
                           where geoCodeNode != null
                           let value = geoCodeNode.Element(capNamespace + "value").Value
                           let valueName = geoCodeNode.Element(capNamespace + "valueName").Value
                           select new GeoCode(valueName, value);

            area.GeoCodes.AddRange(geoCodes);

            var altitudeNode = areaElement.Element(capNamespace + "altitude");
            if (altitudeNode != null)
                area.Altitude = TryParseInt(altitudeNode.Value);

            var ceilingNode = areaElement.Element(capNamespace + "ceiling");
            if (ceilingNode != null)
                area.Ceiling = TryParseInt(ceilingNode.Value);
            return area;
        }

        private static Resource ParseResource(XElement resourceElement)
        {
            var resource = new Resource();

            var capNamespace = resourceElement.Name.Namespace;

            //<resource>
            //    <resourceDesc>Image file (GIF)</resourceDesc>
            //    <mimeType>image/gif</mimeType>
            //    <size>1</size>
            //    <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            //    <derefUri>derefUri</derefUri>
            //    <digest>digest</digest>
            //</resource>

            var resourceDescNode = resourceElement.Element(capNamespace + "resourceDesc");
            if (resourceDescNode != null)
                resource.Description = resourceDescNode.Value;

            var mimeTypeNode = resourceElement.Element(capNamespace + "mimeType");
            if (mimeTypeNode != null)
                resource.MimeType = mimeTypeNode.Value;

            var sizeNode = resourceElement.Element(capNamespace + "size");
            if (sizeNode != null)
                resource.Size = TryParseInt(sizeNode.Value);

            var uriNode = resourceElement.Element(capNamespace + "uri");
            if (uriNode != null)
                resource.Uri = new Uri(uriNode.Value);

            var derefUriNode = resourceElement.Element(capNamespace + "derefUri");
            if (derefUriNode != null && IsBase64(derefUriNode.Value))
                resource.DereferencedUri = Convert.FromBase64String(derefUriNode.Value);

            var digestNode = resourceElement.Element(capNamespace + "digest");
            if (digestNode != null)
                resource.Digest = digestNode.Value;

            return resource;
        }

        private static DateTimeOffset? TryParseDateTime(string tested)
        {
            DateTimeOffset parsed;
            bool canBeParsed = DateTimeOffset.TryParse(tested, out parsed);
            if (canBeParsed)
                return parsed;
            return null;
        }

        private static int? TryParseInt(string tested)
        {
            int parsed;
            bool canBeParsed = int.TryParse(tested, out parsed);
            if (canBeParsed)
                return parsed;
            return null;
        }

        private static bool IsBase64(string base64)
        {
            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private static IEnumerable<string> GetElements(this string representation)
        { 
            var spaceContainingElements = GetSpaceContainingElements(representation);
            string spaceContainingElementsMarked = representation.MarkElements(spaceContainingElements);

            var elementsWithNoSpace = from address in spaceContainingElementsMarked.Split(' ')
                                      select address;

            var addresses = FillSpaceContainingElements(spaceContainingElements, elementsWithNoSpace);

            return addresses;
        }

        private static string MarkElements(this string representation, IEnumerable<string> spaceContainingElements)
        {
            foreach (var element in spaceContainingElements)
                representation = representation.Replace(element.ToString(), "\"\"");

            return representation;
        }

        private static IEnumerable<string> GetSpaceContainingElements(string representation)
        {
            string pattern = "\"[\\w ]*\"";
            Regex regexObject = new Regex(pattern);
            var spaceContainingElements = from Match match in regexObject.Matches(representation)
                                          select match.Value;

            return spaceContainingElements;
        }

        private static List<string> FillSpaceContainingElements(IEnumerable<string> spaceContainingElements, IEnumerable<string> elementsWithNoSpace)
        {

            var addresses = elementsWithNoSpace.ToList();

            int indexOfSpaceContainingElement = 0;
            for (int index = 0; index < addresses.Count(); index++)
            {
                var currentAddress = addresses.ElementAt(index);
                if (currentAddress.Equals("\"\""))
                {
                    addresses[index] = spaceContainingElements.ElementAt(indexOfSpaceContainingElement).Replace("\"", "");
                    indexOfSpaceContainingElement++;
                }
            }

            return addresses;
        }

    }
}
