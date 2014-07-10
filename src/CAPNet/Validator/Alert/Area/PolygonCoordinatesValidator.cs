using CAPNet.Models;
using System.Linq;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class PolygonCoordinatesValidator : Validator<Polygon>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        public PolygonCoordinatesValidator(Polygon polygon) : base(polygon) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                var wgs84Validators = from coordinate in Entity.Coordinates
                                      select new WGS84Validator(coordinate);

                return from wgs84Validator in wgs84Validators
                       from errors in wgs84Validator.Errors
                       select errors;
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
    }
}
