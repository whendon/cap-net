using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the info sub-element of the alert message.
    /// </summary>
    /// <remarks>
    ///   <list type="number">
    ///     <item>
    ///       <description>
    ///          Multiple occurrences are permitted within a single &lt;alert>.
    ///          If targeting of multiple &lt;info> blocks in the same language overlaps, information in later blocks may expand but may not override the corresponding values in earlier ones. 
    ///          Each set of &lt;info> blocks containing the same language identifier SHALL be treated as a separate sequence.
    ///       </description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///         In addition to the specified sub-elements, MAY contain one or more &lt;resource> blocks and/or one or more &lt;area> blocks.
    ///       </description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class Info
    {
        private string language;

        private readonly ICollection<Parameter> parameters;

        private readonly ICollection<EventCode> eventCodes;

        private readonly ICollection<Category> categories;

        private readonly ICollection<Resource> resources;

        private readonly ICollection<Area> areas;

        private readonly ICollection<ResponseType> responseTypes;

        /// <summary>
        /// 
        /// </summary>
        public readonly string DefaultLanguage = "en-US";

        /// <summary>
        /// 
        /// </summary>
        public Info()
        {
            parameters = new List<Parameter>();
            eventCodes = new List<EventCode>();
            categories = new List<Category>();
            resources = new List<Resource>();
            areas = new List<Area>();
            responseTypes = new List<ResponseType>();
        }

        /// <summary>
        /// Gets or sets the code denoting the language of the info sub-element of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values: Natural language identifier per [RFC 3066].
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          If not present, an implicit default value of "en-US" SHALL be assumed. 
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          A null value in this element SHALL be considered equivalent to “en-US.”
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string Language
        {
            get { return String.IsNullOrWhiteSpace(language) ? DefaultLanguage : language; }
            set { language = value; }
        }

        /// <summary>
        /// The codes denoting the type of action recommended for the target audience 
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///           Code Values:
        ///             “Shelter” – Take shelter in place or per &lt;instruction>
        ///             “Evacuate” – Relocate as instructed in the &lt;instruction>
        ///             “Prepare” – Make preparations per the &lt;instruction>
        ///             “Execute” – Execute a pre-planned activity identified in &lt;instruction>
        ///             “Avoid” – Avoid the subject event as per the &lt;instruction>
        ///             “Monitor” – Attend to information sources as described in &lt;instruction>
        ///             “Assess” – Evaluate the information in this message.  (This value SHOULD NOT be used in public warning applications.)
        ///             “AllClear” – The subject event no longer poses a threat or concern and any follow on action is described in &lt;instruction>
        ///             “None” – No action recommended
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           Multiple instances MAY occur within an &lt;info> block.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<ResponseType> ResponseTypes
        {
            get
            {
                return responseTypes;
            }
        }

        /// <summary>
        /// The codes denoting the category of the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///             “Geo” - Geophysical (inc. landslide)
        ///             “Met” - Meteorological (inc. flood)
        ///             “Safety” - General emergency and public safety
        ///             “Security” - Law enforcement, military, homeland and local/private security
        ///             “Rescue” - Rescue and recovery
        ///             “Fire” - Fire suppression and rescue
        ///             “Health” - Medical and public health
        ///             “Env” - Pollution and other environmental
        ///             “Transport” - Public and private transportation
        ///             “Infra” - Utility, telecommunication, other non-transport infrastructure
        ///             “CBRNE” – Chemical, Biological, Radiological, Nuclear or High-Yield Explosive threat or attack
        ///             “Other” - Other events
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///            Multiple instances MAY occur within an &lt;info> block.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        
        public ICollection<Category> Categories
        {
            get { return categories; }
        }

        /// <summary>
        /// The text denoting the type of the subject event of the alert message
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// The code denoting the urgency of the subject event of the alert message 
        /// </summary>
        public Urgency Urgency { get; set; }

        /// <summary>
        /// The code denoting the severity of the subject event of the alert message 
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// The code denoting the certainty of the subject event of the alert message 
        /// </summary>
        public Certainty Certainty { get; set; }

        /// <summary>
        /// The text describing the intended audience of the alert message 
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The effective time of the information of the alert message 
        /// </summary>
        public DateTimeOffset? Effective { get; set; }

        /// <summary>
        /// The expected time of the beginning of the subject event of the alert message 
        /// </summary>
        public DateTimeOffset? Onset { get; set; }

        /// <summary>
        /// The expiry time of the information of the alert message 
        /// </summary>
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// The text naming the originator of the alert message 
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// The text headline of the alert message 
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// The text describing the subject event of the alert message 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The text describing the recommended action to be taken by recipients of the alert message 
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// The identifier of the hyperlink associating additional information with the alert message 
        /// </summary>
        public Uri Web { get; set; }

        /// <summary>
        /// The text describing the contact for follow-up and confirmation of the alert message 
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// System-specific additional parameters associated
        /// with the alert message (OPTIONAL)
        /// </summary>
        public ICollection<Parameter> Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// A system-specific codes identifying the event type of the alert message 
        /// </summary>
        public ICollection<EventCode> EventCodes
        {
            get { return eventCodes; }
        }

        /// <summary>
        /// Refers to additional files with supplemental information related to this info element
        /// </summary>
        public ICollection<Resource> Resources
        {
            get { return resources; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Area> Areas
        {
            get { return areas; }
        }
    }
}
