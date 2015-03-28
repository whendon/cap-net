using System.Xml.Linq;

namespace EDXLNet.Models
{
    public class ContentXml
    {
        /// <summary>
        /// The &lt;EmbeddedXMLContent> element is an open container for valid XML from an
        /// explicit namespaced XML Schema.
        /// XML content from any namespace other than the DE 2.0 namespace
        /// CONDITIONAL, REQUIRED if parent element ContentXml is present, MAY use only one
        /// per content object
        /// 1. The content MUST be a separately-namespaced well-formed XML document.
        /// 2. The enclosed XML content MUST be explicitly namespaced as defined in the
        ///    enclosing &lt;EmbeddedXMLContent> tag.
        /// 3. Enclosed XML content may be encrypted and/or signed within this element.
        /// 4. This element MUST be present if parent element, ContentXML, is present.
        /// </summary>
        public XElement EmbeddedXml { get; set; }
    }
}