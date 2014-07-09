namespace CAPNet.Models
{
    /// <summary>
    /// A system-specific code identifying the event type of the alert message 
    /// </summary>
    public class EventCode : NamedValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        public EventCode(string valueName, string value)
            : base(valueName, value)
        {
        }
    }
}
