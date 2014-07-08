using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the info sub-element of the alert message.
    /// </summary>
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
        public string Language
        {
            get { return String.IsNullOrWhiteSpace(language) ? DefaultLanguage : language; }
            set { language = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ResponseType> ResponseTypes
        {
            get
            {
                return responseTypes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// Refers to additional files with supplemental information related to this <info> element
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
