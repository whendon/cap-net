using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the alert message.
    /// </summary>
    /// <remarks>
    ///   <list type="number">
    ///     <item>
    ///       <description>
    ///         Used to collate multiple messages referring to different aspects of the same incident.
    ///       </description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///          If multiple incident identifiers are referenced, they SHALL be separated by whitespace. 
    ///          Incident names including whitespace SHALL be surrounded by double-quotes.
    ///       </description>
    ///     </item>
    ///     </list>
    /// </remarks>
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
        ///   </list>
        /// </remarks>
        public DateTimeOffset? Sent { get; set; }

        /// <summary>
        /// The code denoting the appropriate handling of the alert message 
        /// </summary>
        
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
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         Required when &lt;scope> is “Private”, optional when &lt;scope> is “Public” or “Restricted”.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Each recipient SHALL be identified by an identifier or an address.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          Multiple space-delimited addresses MAY be included.  Addresses including whitespace MUST be enclosed in double-quotes.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
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
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Any user-defined flag or special code used to flag the alert message for special handling.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Multiple instances MAY occur.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string Code { get; set; }

        /// <summary>
        /// The text describing the purpose or significance of the alert message 
        /// </summary>
        /// <remarks>
        ///   <item>
        ///     <description>
        ///        The message note is primarily intended for use with &lt;status> “Exercise” and &lt;msgType> “Error”.
        ///     </description>
        ///   </item>
        /// </remarks>
        public string Note { get; set; }

        /// <summary>
        /// The group listing identifying earlier message(s) referenced by the alert message 
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The extended message identifier(s) (in the form sender,identifier,sent) of an earlier CAP message or messages referenced by this one.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         If multiple messages are referenced, they SHALL be separated by whitespace.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string References { get; set; }

        /// <summary>
        /// The group listing naming the referent incident(s) of the alert message 
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Used to collate multiple messages referring to different aspects of the same incident.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           If multiple incident identifiers are referenced, they SHALL be separated by whitespace.  Incident names including whitespace SHALL be surrounded by double-quotes.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
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

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Info> Info
        {
            get { return info; }
        }
    }
}
