using System;

namespace CAPNet.Models
{
    /// <summary>
    /// Refers to an additional file with supplemental information related to this info element; e.g., an image or audio file.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The text describing the type and content of the resource 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The identifier of the MIME content type and sub-type describing the resource file 
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The integer indicating the size of the resource 
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// The identifier of the hyperlink for the resource file 
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// The base-64 encoded data content of the resource file
        /// </summary>
        public byte[] DereferencedUri { get; set; }

        /// <summary>
        /// The code representing the digital digest (“hash”) computed from the resource file 
        /// </summary>
        public string Digest { get; set; }
    }
}
