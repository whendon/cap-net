using System;

namespace EDXLNet.Models
{
    public class EdxlDistribution
    {
        /// <summary>
        /// The unique identifier of this distribution message.
        /// REQUIRED, MUST be used once and only once
        /// 1. Uniqueness is assigned by the sender to be unique for that sender.
        /// 2. The identifier MUST be a properly formed -escaped if necessary- XML string.
        /// 3. The string length of the identifier MUST be less than 1024.
        /// </summary>
        public string DistributionId { get; set; }

        /// <summary>
        /// The unique identifier of the sender.
        /// REQUIRED, MUST be used once and only once
        /// 1. Uniquely identifies human parties, systems, services, or devices that are all
        ///    potential senders of the distribution message.
        /// 2. In the form actor@domain-name.
        /// 3. Uniqueness of the domain-name is guaranteed through use of the Internet Domain
        ///    Name System, and uniqueness of the actor name enforced by the domain owner.
        /// 4. The identifier MUST be a properly formed -escaped if necessary- XML string.
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        /// The date and time the distribution message was sent.
        /// REQUIRED, MUST be used once and only once
        /// 1. The Date Time combination must include the offset time for time zone.
        ///    Must be in the restricted W3C format for the XML [dateTime] data type,
        ///    see ct:EDXLDateTimeType.
        /// </summary>
        public DateTimeOffset DateTimeSent { get; set; }

        /// <summary>
        /// The date and time the distribution message should expire.
        /// REQUIRED, MUST be used once and only once
        /// 1. The Date Time combination must include the offset time for time zone.
        ///    Must be in the restricted W3C format for the XML [dateTime] data type,
        ///    see ct:EDXLDateTimeType.
        /// </summary>
        public DateTimeOffset DateTimeExpires { get; set; }

        /// <summary>
        /// The action-ability of the message.
        /// A choice between a user-defined value or a default value
        /// REQUIRED, MUST be used once and only once
        /// 1. If the default value list is used, then the ValueListURI must be:
        ///    “urn:oasis:names:tc:emergency:EDXL:DE:2.0:Defaults:StatusType” and
        ///    the Value must be one of:
        ///    a. Actual - "Real-world" information for action
        ///    b. Exercise - Simulated information for exercise participants
        ///    c. System - Messages regarding or supporting network functions
        ///    d. Test - Discardable messages for technical testing only.
        /// 2. The status MUST be a properly formed -escaped if necessary- XML string.
        /// </summary>
        public DistributionStatus DistributionStatus { get; set; }

        /// <summary>
        /// The function of the message.
        /// A choice between a user-defined value or a default value
        /// REQUIRED, MUST be used once and only once
        /// 1. The list and associated value(s) are in the form:
        ///        <DistributionType>
        ///            <ct:ValueListURI>ValueListURI</ct:ValueListURI>
        ///            <ct:Value>value</ct:Value>
        ///        </DistributionType>
        ///    The content of &lt;ct:ValueListURI> is the Uniform Resource Identifier
        ///    of a published list of values and definitions, and the content of
        ///    &lt;ct:Value> is a string (which may represent a number) denoting the value itself.
        /// 2. Only a single value may be specified
        /// 3. If the default value list is used,  the ValueListURI must be:
        ///    ”urn:oasis;names:tc:emergency:EDXL:DE2.0:Defaults:StatusType” and
        ///    the Value must be one of:
        ///    a. Report - New information regarding an incident or activity
        ///    b. Update - Updated information superseding a previous message
        ///    c. Cancel - A cancellation or revocation of a previous message
        ///    d. Request - A request for resources, information or action
        ///    e. Response - A response to a previous request
        ///    f. Dispatch - A commitment of resources or assistance
        ///    g. Ack - Acknowledgment of receipt of an earlier message
        ///    h. Error - Rejection of an earlier message (for technical reasons)
        ///    i. SensorConfiguration - These messages are for reporting configuration
        ///       during power up or after Installation or Maintenance.
        ///    j. SensorControl - These are messages used to control sensors/sensor
        ///       concentrator components behavior.
        ///    k. SensorStatus - These are concise messages which report sensors/sensor
        ///       concentrator component status or state of health.
        ///    l. SensorDetection - These are high priority messages which report sensor
        ///       detections.
        /// 4. The status MUST be a properly formed -escaped if necessary- XML string.
        /// </summary>
        public DistributionKind DistributionKind { get; set; }

        /// <summary>
        /// A container for the ContentObject and any Links among content objects
        /// OPTIONAL, MAY be used once and only once; may be used outside of EDXLDistribution
        /// if an alternative envelope to &lt;EDXLDistribution> is used.
        /// 1. The &lt;Content> block must contain one or more &lt;ContentObject> blocks and optionally
        ///    one ore more &lt;Link> elements.
        /// 2. This element can be the source or destination for a link. See Section 1.3.5.
        /// </summary>
        public Content Content { get; set; }
    }
}
