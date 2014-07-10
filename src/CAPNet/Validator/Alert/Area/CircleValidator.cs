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
    public class CircleValidator : Validator<Circle>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="circle"></param>
        public CircleValidator(Circle circle) : base(circle) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new CircleError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var wgs84Validator = new WGS84Validator(Entity.Center);
                return !wgs84Validator.Errors.Any();
            }
        }
    }
}
