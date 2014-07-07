using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;
using System.Text.RegularExpressions;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class MultipleAddressesValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public MultipleAddressesValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return  (!Entity.Addresses.Contains(" ") || (Entity.Addresses[0] == '\"' && Entity.Addresses[Entity.Addresses.Length - 1] == '\"'));
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
                    yield return new AddressesRequiredWhenScopeError();
            }
        }
    }
}
