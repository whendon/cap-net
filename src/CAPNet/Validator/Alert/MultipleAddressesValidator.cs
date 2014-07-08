using CAPNet.Models;
using System.Collections.Generic;

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
                if (Entity.Addresses != null)
                    return (!Entity.Addresses.Contains(" ") || (Entity.Addresses[0] == '\"' && Entity.Addresses[Entity.Addresses.Length - 1] == '\"'));
                else return true;
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
