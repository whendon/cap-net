using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
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
                var valueIsNotNull = Entity.Value != null;
                var valueNameIsNotNull = Entity.ValueName != null;

                return valueIsNotNull && valueNameIsNotNull;
            }
        }
    }
}
