using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// Restriction is used only when Alert.Scope is Scope.Restricted
    /// </summary>
    public class RestrictionValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public RestrictionValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new RestrictionError();
            }
        }

        /// <summary>
        /// The restriction validator is valid in two cases :
        ///     1. Alert.Scope is Restricted and Restriction is not null
        ///     2. Alert.Scope is not Restricted and Restriction is null
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return ((Entity.Scope == Scope.Restricted && Entity.Restriction != null) || (Entity.Scope != Scope.Restricted && string.IsNullOrEmpty(Entity.Restriction)));
            }
        }
    }
}
