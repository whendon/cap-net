using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
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
                var valueIsNotNull = Entity.Value != null;
                var valueNameIsNotNull = Entity.ValueName != null;

                return valueIsNotNull && valueNameIsNotNull;
            }
        }
    }
}
