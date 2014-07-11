using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// Parameter must have value and valueName not null
    /// </summary>
    public class ParameterValidator : Validator<Parameter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public ParameterValidator(Parameter parameter) : base(parameter) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new ParameterError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Value != null && Entity.ValueName != null;
            }
        }
    }
}
