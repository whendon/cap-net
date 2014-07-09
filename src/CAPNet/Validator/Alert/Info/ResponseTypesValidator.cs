using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseTypesValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public ResponseTypesValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from responseType in Entity.ResponseTypes
                       from error in GetErrors(responseType)
                       select error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public IEnumerable<Error> GetErrors(ResponseType responseType)
        {
            var responseTypeValidators = from type in Assembly.GetExecutingAssembly().GetTypes()
                                        where typeof(IValidator<ResponseType>).IsAssignableFrom(type)
                                        select (IValidator<ResponseType>)Activator.CreateInstance(type, responseType);

            return from validator in responseTypeValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
