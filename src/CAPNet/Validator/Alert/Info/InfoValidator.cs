using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class InfoValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public InfoValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get 
            {
                return from info in Entity.Info
                       from error in GetErrors(info)
                       select error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IEnumerable<Error> GetErrors(Info info)
        {
            var infoValidators = from type in Assembly.GetExecutingAssembly().GetTypes()
                                 where typeof(IValidator<Info>).IsAssignableFrom(type)
                                 select (IValidator<Info>)Activator.CreateInstance(type, info);

            return from validator in infoValidators
                   from error in validator.Errors
                   select error;
        }

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
    }
}
