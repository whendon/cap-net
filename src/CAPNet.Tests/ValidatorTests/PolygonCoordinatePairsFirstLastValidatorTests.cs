using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class PolygonCoordinatePairsFirstLastValidatorTests
    {
        [Fact]
        public void PolygonWithFirstCoordinatePairDifferentFromLastCoordinatePairIsInvalid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 39.47,-120.14");
            var polygonCoordinatePairsFirstLastValidator = new PolygonCoordinatePairsFirstLastValidator(polygon);
            Assert.False(polygonCoordinatePairsFirstLastValidator.IsValid);

            var pairErrors = from error in polygonCoordinatePairsFirstLastValidator.Errors
                             where error.GetType() == typeof(PolygonCoordinatePairsFirstLastError)
                             select error;
            Assert.NotEmpty(pairErrors);
        }

        [Fact]
        public void PolygonWithFirstCoordinatePairEqualToLastCoordinatePairsIsValid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            var polygonCoordinatePairsFirstLastValidator = new PolygonCoordinatePairsFirstLastValidator(polygon);
            Assert.True(polygonCoordinatePairsFirstLastValidator.IsValid);

            var pairErrors = from error in polygonCoordinatePairsFirstLastValidator.Errors
                             where error.GetType() == typeof(PolygonCoordinatePairsFirstLastError)
                             select error;
            Assert.Empty(pairErrors);
        }
    }
}
