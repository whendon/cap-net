using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
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
                    yield return new GeocodeError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var valueIsNotNull = Entity.Value != null;
                var valueNameIsNotNull = Entity.ValueName != null;

                return valueIsNotNull && valueNameIsNotNull;
            }
        }
    }
}
