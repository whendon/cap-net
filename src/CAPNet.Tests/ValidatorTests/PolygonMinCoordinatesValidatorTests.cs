using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class PolygonMinCoordinatesValidatorTests
    {
        [Fact]
        public void PolygonWith5CoordinatePairsIsInvalid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            var polygonMinCoordinatesValidator = new PolygonMinCoordinatesValidator(polygon);
            Assert.False(polygonMinCoordinatesValidator.IsValid);
            Assert.Equal(typeof(PolygonMinCoordinatesError), polygonMinCoordinatesValidator.Errors.First().GetType());
        }

        [Fact]
        public void PolygonWith4CoordinatePairsIsValid()
        {
            var polygon = new Polygon("38.47,-120.14 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            var polygonMinCoordinatesValidator = new PolygonMinCoordinatesValidator(polygon);
            Assert.True(polygonMinCoordinatesValidator.IsValid);
            Assert.Empty(polygonMinCoordinatesValidator.Errors);
        }
    }
}
