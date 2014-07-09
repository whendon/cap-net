using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class EventRequiredValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public EventRequiredValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Entity.Event);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return (new EventRequiredError());
            }
        }
    }
}
