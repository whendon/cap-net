using CAPNet.Models;
using System;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class WGS84Validator : Validator<Coordinate>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        public WGS84Validator(Coordinate coordinate) : base(coordinate) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new WGS84Error();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var longitudeIsValid = -180 <= Entity.Longitude && Entity.Longitude <= 180;
                var latitudeIsValid = -90 <= Entity.Latitude && Entity.Latitude <= 90;

                return longitudeIsValid && latitudeIsValid;
            }
        }
    }
}
