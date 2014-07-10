using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class CircleValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public CircleValidator(Area area) : base(area) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                var wgs84Validators = from circle in Entity.Circles
                                      select new WGS84Validator(circle.Center);

                return from wgs84Validator in wgs84Validators
                       from error in wgs84Validator.Errors
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
    }
}
