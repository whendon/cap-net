using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// Any geographically-based code to describe a message must have value and valueName not null
    /// </summary>
    public class GeoCodeValidator : Validator<GeoCode>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="geoCode"></param>
        public GeoCodeValidator(GeoCode geoCode) : base(geoCode) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new GeoCodeError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Value != null && Entity.ValueName != null;
            }
        }
    }
}
