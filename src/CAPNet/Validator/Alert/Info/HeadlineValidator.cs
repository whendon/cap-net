using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// The text headline of the alert message is not required , but IT MUST have length less than 160 characters
    /// </summary>
    public class HeadlineValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public HeadlineValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new HeadlineError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.Headline == null)
                    return true;
                return Entity.Headline.Length <= 160;
            }
        }
    }
}
