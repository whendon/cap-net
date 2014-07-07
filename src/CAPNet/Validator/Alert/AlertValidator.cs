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
    public class AlertValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        public AlertValidator() : base(new Alert()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public AlertValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from error in GetErrors(Entity)
                       select error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        private IEnumerable<Error> GetErrors(Alert alert)
        {
            var alertValidators = new List<Validator<Alert>>();
            alertValidators.Add(new IdentifierRequiredValidator(alert));
            alertValidators.Add(new SenderRequiredValidator(alert));
            alertValidators.Add(new StatusRequiredValidator(alert));
            alertValidators.Add(new MessageTypeRequiredValidator(alert));

            return from validator in alertValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
