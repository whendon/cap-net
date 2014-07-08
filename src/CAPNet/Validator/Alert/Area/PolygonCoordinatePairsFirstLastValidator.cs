using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class PolygonCoordinatePairsFirstLastValidator : Validator<Polygon>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        public PolygonCoordinatePairsFirstLastValidator(Polygon polygon) : base(polygon) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var firstCoordinate = Entity.Coordinates.First();
                var lastCoordinate = Entity.Coordinates.Last();
                return firstCoordinate.Equals(lastCoordinate);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new PolygonCoordinatePairsFirstLastError();
            }
        }
    }
}
