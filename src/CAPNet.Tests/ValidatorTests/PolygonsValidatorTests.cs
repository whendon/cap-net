using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class PolygonsValidatorTests
    {
        [Fact]
        public void PolygonsWith5CoordinatePairsAndFirstPairEqualToLastIsValid()
        {
            var area = new Area();
            area.Description = "Canada";
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            area.Polygons.Add(polygon);
            var polygonValidator = new PolygonsValidator(area);
            Assert.True(polygonValidator.IsValid);
        }

        [Fact]
        public void PolygonsWith5CoordinatePairsAndFirstPairDifferentOfLastIsInvalid()
        {
            var area = new Area();
            area.Description = "Canada";
            var polygon = new Polygon("98.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            area.Polygons.Add(polygon);
            var polygonValidator = new PolygonsValidator(area);
            Assert.False(polygonValidator.IsValid);
            var polygonsErrors = from error in polygonValidator.Errors
                                 where error.GetType() == typeof(PolygonCoordinatePairsFirstLastError)
                                 select error;
            Assert.NotEmpty(polygonsErrors);
        }

        [Fact]
        public void PolygonsWith3CoordinatePairsAndFirstPairEqualToLastIsInvalid()
        {
            var area = new Area();
            area.Description = "Canada";
            var polygon = new Polygon("38.47,-120.14 38.52,-119.74 38.47,-120.14");
            area.Polygons.Add(polygon);
            var polygonValidator = new PolygonsValidator(area);
            Assert.False(polygonValidator.IsValid);
            var polygonsErrors = from error in polygonValidator.Errors
                                 where error.GetType() == typeof(PolygonMinCoordinatesError)
                                 select error;
            Assert.NotEmpty(polygonsErrors);
        }
    }
}
