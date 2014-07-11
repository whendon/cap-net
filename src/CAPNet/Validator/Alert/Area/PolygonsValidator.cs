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
    public class PolygonsValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public PolygonsValidator(Area area) : base(area) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from polygon in Entity.Polygons
                       from error in GetErrors(polygon)
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
        /// <param name="polygon"></param>
        /// <returns></returns>
        private IEnumerable<Error> GetErrors(Polygon polygon)
        {
            var polygonValidators = from type in Assembly.GetExecutingAssembly().GetTypes()
                                    where typeof(IValidator<Polygon>).IsAssignableFrom(type)
                                    select (IValidator<Polygon>)Activator.CreateInstance(type, polygon);

            return from validator in polygonValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
