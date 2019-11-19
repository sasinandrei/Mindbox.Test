using System;
using Xunit;

namespace Mindbox.Test.AreaCalculation.Tests
{
    public class TriangleTest
    {
        [Theory]
        [InlineData(203, 208, 145, 13932.462)]
        [InlineData(3, 4, 5, 12.5)]
        [InlineData(5, 12, 13, 84.5)]
        public void TriangleArea_Calculation(double a, double b, double c, double area)
        {
            var shape = new Triangle(a, b, c);
            Assert.Equal(area, shape.Area, 3);
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        public void Triangle_EdgeShouldBeMoreThan0_Throw(double a, double b, double c)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            string argumentName;
            if (a <= 0)
            {
                argumentName = "a";
            }
            else if (b <= 0)
            {
                argumentName = "b";
            }
            else
            {
                argumentName = "c";
            }

            Assert.Equal($"Side must be greater than 0\r\nParameter name: {argumentName}", ex.Message);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        public void Triangle_TriangleInequalityTheorem_Throw(double a, double b, double c)
        {
            var ex = Assert.Throws<Exception>(() => new Triangle(a, b, c));
            Assert.Equal("The sum of the lengths of any 2 sides of a triangle must be greater than the third side", ex.Message);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(203, 208, 145)]
        public void Triangle_IsTriangleInequalityTheoremSuited_True(double a, double b, double c)
        {
            var result = Triangle.IsTriangleInequalityTheoremSuited(a, b, c);
            Assert.True(result);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        public void Triangle_IsTriangleInequalityTheoremSuited_False(double a, double b, double c)
        {
            var result = Triangle.IsTriangleInequalityTheoremSuited(a, b, c);
            Assert.False(result);
        }

        [Theory]
        [InlineData(5, 12, 13)]
        [InlineData(3, 4, 5)]
        public void Triangle_IsRight_True(double a, double b, double c)
        {
            var shape = new Triangle(a, b, c);
            Assert.True(shape.IsRight);
        }
        
        [Theory]
        [InlineData(203, 208, 145)]
        [InlineData(3, 3, 5)]
        public void Triangle_IsRight_False(double a, double b, double c)
        {
            var shape = new Triangle(a, b, c);
            Assert.False(shape.IsRight);
        }
    }
}
