using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentifierRequiredValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public IdentifierRequiredValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new InvalidIdentifierError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !RestrictiveCharacters.restrictiveCharacters.Any(restrictiveCharacter => Entity.Identifier.Contains(restrictiveCharacter.ToString()));
            }
        }
    }
}
