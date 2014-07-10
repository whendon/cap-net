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
                var latitudeIsValid = Entity.Y >= -90 && Entity.Y <= 90;
                var longitudeIsValid = Entity.X >= -180 && Entity.X <= 180;

                return latitudeIsValid && longitudeIsValid;
            }
        }
    }
}
