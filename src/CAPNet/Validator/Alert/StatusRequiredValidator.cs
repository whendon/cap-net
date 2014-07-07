using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusRequiredValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public StatusRequiredValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Enum.IsDefined(typeof(Status), this.Entity.Status);
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
                    yield return new StatusRequiredError();
            }
        }
    }
}
