using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// Validator of the multiple instances that MAY occur within an area block.
    /// </summary>
    public class GeoCodesValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public GeoCodesValidator(Area area) : base(area) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from geoCode in Entity.GeoCodes
                       from error in GetErrors(geoCode)
                       select error;
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geoCode"></param>
        /// <returns></returns>
        private IEnumerable<Error> GetErrors(GeoCode geoCode)
        {
            var geocodeValidators = from type in Assembly.GetExecutingAssembly().GetTypes()
                                    where typeof(IValidator<GeoCode>).IsAssignableFrom(type)
                                    select (IValidator<GeoCode>)Activator.CreateInstance(type, geoCode);

            return from validator in geocodeValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
