using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class PolygonMinCoordinatesValidatorTests
    {
        [Fact]
        public void PolygonWith5CoordinatePairsIsValid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            var polygonMinCoordinatesValidator = new PolygonMinCoordinatesValidator(polygon);
            Assert.True(polygonMinCoordinatesValidator.IsValid);
        }

        [Fact]
        public void PolygonWith4CoordinatePairsIsValid()
        {
            var polygon = new Polygon("38.47,-120.14 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            var polygonMinCoordinatesValidator = new PolygonMinCoordinatesValidator(polygon);
            Assert.True(polygonMinCoordinatesValidator.IsValid);
            Assert.Empty(polygonMinCoordinatesValidator.Errors);
        }

        [Fact]
        public void PolygonWith3CoordinatePairsIsInvalid()
        {
            var polygon = new Polygon("38.47,-120.14 38.47,-120.14");
            var polygonMinCoordinatesValidator = new PolygonMinCoordinatesValidator(polygon);
            Assert.False(polygonMinCoordinatesValidator.IsValid);
            Assert.NotEmpty(polygonMinCoordinatesValidator.Errors);
        }
    }
}
