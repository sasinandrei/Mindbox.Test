using System;
using Xunit;

namespace Mindbox.Test.AreaCalculation.Tests
{
    public class CircleTest
    {
        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(50, Math.PI * 2500)]
        [InlineData(0.5, Math.PI * 0.25)]
        public void CircleArea_Calculation(double radius, double area)
        {
            var shape = new Circle(radius);
            Assert.Equal(area, shape.Area);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Circle_RadiusShouldBeMoreThan0_Throw(double radius)
        {
            var ex = Assert.Throws<Exception>(() => new Circle(radius));
            Assert.Equal("Radius must be greater than 0", ex.Message);
        }
    }
}
