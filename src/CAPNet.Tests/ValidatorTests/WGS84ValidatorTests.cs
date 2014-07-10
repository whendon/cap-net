using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class WGS84ValidatorTests
    {
        [Fact]
        public void CoordinatesWithInvalidLatitudeIsInvalid()
        {
            var coordinate = new Coordinate(120,280);
            var wgs84Validator = new WGS84Validator(coordinate);
            Assert.False(wgs84Validator.IsValid);
        }

        [Fact]
        public void CoordinatesWithValidLatitudeAndLongitudeIsValid()
        {
            var coordinate = new Coordinate(70, 120);
            var wgs84Validator = new WGS84Validator(coordinate);
            Assert.False(wgs84Validator.IsValid);
        }
    }
}
