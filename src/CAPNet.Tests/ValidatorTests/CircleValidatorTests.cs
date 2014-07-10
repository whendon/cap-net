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
            var coordinate = new Coordinate(400, 400);
            var circle = new Circle(coordinate, 14);
            area.Circles.Add(circle);

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
            var coordinate = new Coordinate(50, 50);
            var circle = new Circle(coordinate, 55);
            area.Circles.Add(circle);

            var circleValidator = new CircleValidator(area);
            Assert.True(circleValidator.IsValid);
        }
    }
}
