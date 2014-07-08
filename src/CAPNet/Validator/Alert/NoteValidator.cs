using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// Validator for Note 
    /// </summary>
    public class NoteValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public NoteValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new NoteError();
            }
        }

        /// <summary>
        /// Note is used when status is Exercise or MessageType is Error
        /// </summary>
        public override bool IsValid
        {
            get
            {
                // if Status is Exercise or MessageType Error , Note should be not null or not empty in order the overall condition is true;  
                if (Entity.Status == Status.Excercise || Entity.MessageType == MessageType.Error)
                {
                    if (!string.IsNullOrEmpty(Entity.Note))
                        return true;
                    else
                        return false;
                }
                else return true;
            }
        }
    }
}
