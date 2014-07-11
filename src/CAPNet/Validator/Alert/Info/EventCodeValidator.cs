using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// A system-specific code identifying the event type of the alert message mut have value and valueName not null !
    /// </summary>
    public class EventCodeValidator : Validator<EventCode>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventCode"></param>
        public EventCodeValidator(EventCode eventCode) : base(eventCode) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new EventCodeError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Value != null && Entity.ValueName != null;
            }
        }
    }
}
