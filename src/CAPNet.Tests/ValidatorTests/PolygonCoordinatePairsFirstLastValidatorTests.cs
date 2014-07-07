using CAPNet.Models;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class PolygonCoordinatePairsFirstLastValidatorTests
    {
        [Fact]
        public void PolygonWithFirstCoordinatePairDifferentFromLastCoordinatePairIsInvalid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 39.47,-120.14");
            var polygonCoordinatePairsFirstLastValidator = new PolygonCoordinatePairsFirstLastValidator(polygon);
            Assert.False(polygonCoordinatePairsFirstLastValidator.IsValid);
        }

        [Fact]
        public void PolygonWithFirstCoordinatePairEqualToLastCoordinateParisIsValid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            var polygonCoordinatePairsFirstLastValidator = new PolygonCoordinatePairsFirstLastValidator(polygon);
            Assert.True(polygonCoordinatePairsFirstLastValidator.IsValid);
        }
    }
}
