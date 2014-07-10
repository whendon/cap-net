using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class CircleValidatorTests
    {
        [Fact]
        public void CircleWithInvalidCoordinatesIsInvalid()
        {
            var area = new Area();
            var invalidCoordinate = new Coordinate(400, 400);
            var invalidCircle = new Circle(invalidCoordinate, 14);
            area.Circles.Add(invalidCircle);

            var circleValidator = new CircleValidator(area);
            Assert.False(circleValidator.IsValid);

            var errors = from error in circleValidator.Errors
                         where error.GetType() == typeof(WGS84Error)
                         select error;
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void CircleWithValidCoordinatesIsValid()
        {
            var area = new Area();
            var validCoordinate = new Coordinate(50, 50);
            var validCircle = new Circle(validCoordinate, 55);
            area.Circles.Add(validCircle);

            var circleValidator = new CircleValidator(area);
            Assert.True(circleValidator.IsValid);
        }
    }
}
