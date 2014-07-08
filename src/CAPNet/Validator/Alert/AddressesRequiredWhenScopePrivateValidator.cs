using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressesRequiredWhenScopePrivateValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public AddressesRequiredWhenScopePrivateValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var scopeIsNotPrivate = Entity.Scope != Scope.Private;
                var addressesIsNotNull = !string.IsNullOrEmpty(Entity.Addresses);

                return scopeIsNotPrivate || addressesIsNotNull;
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
