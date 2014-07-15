using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the alert message.
    /// </summary>
    public class Alert
    {
        /// <summary>
        /// 
        /// </summary>
        public Alert()
        {
            info = new List<Info>();
            addresses = new List<string>();
            incidents = new List<string>();
            references = new List<string>();
        }

        /// <summary>
        /// The identifier of the alert message 
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         A number or string uniquely identifying this message, assigned by the sender.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         MUST NOT include spaces, commas or restricted characters (&lt; and &amp;).
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public string Identifier { get; set; }

        /// <summary>
        /// The identifier of the sender of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         Identifies the originator of this alert. Guaranteed by assigner to be unique globally; e.g., may be based on an Internet domain name.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         MUST NOT include spaces, commas or restricted characters (&lt; and &amp;).
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public string Sender { get; set; }

        /// <summary>
        /// The time and date of the origination of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         The date and time SHALL be represented in the DateTime Data Type (See Implementation Notes) format (e.g., "2002-05-24T16:49:00-07:00" for 24 May 2002 at 16:49 PDT).
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Alphabetic timezone designators such as "Z" MUST NOT be used. The timezone for UTC MUST be represented as "-00:00".
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public DateTimeOffset? Sent { get; set; }

        /// <summary>
        /// The code denoting the appropriate handling of the alert message 
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///            “Actual” - Actionable by all targeted recipients
        ///            “Exercise” - Actionable only by designated exercise participants; exercise identifier SHOULD appear in &lt;note>
        ///            “System” - For messages that support alert network internal functions
        ///            “Test” - Technical testing only, all recipients disregard
        ///            “Draft” – A preliminary template or draft, not actionable in its current form
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Status Status { get; set; }

        /// <summary>
        /// The code denoting the nature of the alert message 
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// The text identifying the source of the alert message 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The code denoting the intended distribution of the alert message 
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// The text describing the rule for limiting distribution of the restricted alert message 
        /// </summary>
        public string Restriction { get; set; }

        /// <summary>
        /// The group listing of intended recipients of the alert message 
        /// </summary>
        public ICollection<string> Addresses
        {
            get
            {
                return addresses;
            }
        }

        /// <summary>
        /// The code denoting the special handling of the alert message 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The text describing the purpose or significance of the alert message 
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// The group listing identifying earlier message(s) referenced by the alert message 
        /// </summary>
        public ICollection<string> References
        {
            get
            {
                return references;
            }
        }

        /// <summary>
        /// The group listing naming the referent incident(s) of the alert message 
        /// </summary>
        public ICollection<string> Incidents
        {
            get
            {
                return incidents;
            }
        }

        private readonly ICollection<Info> info;
        private readonly ICollection<string> addresses;
        private readonly ICollection<string> incidents;
        private readonly ICollection<string> references;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Info> Info
        {
            get { return info; }
        }
    }
}
