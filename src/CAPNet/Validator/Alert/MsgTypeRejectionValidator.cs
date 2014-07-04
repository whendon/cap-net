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
    public class MsgTypeRejectionValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public MsgTypeRejectionValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                yield return new MsgTypeRejectionError();
            }
        }

        /// <summary>
        /// Message Type that is Error should have description in note
        /// </summary>
        public override bool IsValid
        {
            get 
            {
                return !Entity.MessageType.Equals(MessageType.Error) || (!string.IsNullOrEmpty(Entity.Note));
            }
        }
    }
}
