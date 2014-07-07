using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class SenderRequiredValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public SenderRequiredValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new SenderError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !RestrictiveCharacters.restrictiveCharacters.Any(restrictiveCharacter => Entity.Sender.Contains(restrictiveCharacter.ToString()));
            }
        }
    }
}
