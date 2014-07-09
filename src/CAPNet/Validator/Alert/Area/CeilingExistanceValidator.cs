using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// ceiling MUST NOT be used except in combination with the altitude element.
    /// </summary>
    public class CeilingExistanceValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public CeilingExistanceValidator(Area area) : base(area) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new CeilingExistanceError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var altitudeAndCeilingHaveValue = Entity.Altitude.HasValue && Entity.Ceiling.HasValue;
                var norAltitudeAndNorCeilingHaveValue = !Entity.Altitude.HasValue && !Entity.Ceiling.HasValue;

                return altitudeAndCeilingHaveValue || norAltitudeAndNorCeilingHaveValue;
            }
        }
    }
}
