using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressesRequiredWhenScopeValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public AddressesRequiredWhenScopeValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get 
            {
                return !(Entity.Scope == Scope.Private && string.IsNullOrEmpty(Entity.Addresses));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                yield return new AddressesRequiredWhenScopeError();
            }
        }
    }
}
