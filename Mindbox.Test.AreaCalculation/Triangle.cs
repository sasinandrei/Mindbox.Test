using System;
using System.Linq;

namespace Mindbox.Test.AreaCalculation
{
    public class Triangle : IShape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        
        public double Area
        {
            get
            {
                if (IsRight)
                {
                    var c = Math.Max(Math.Max(A, B), C);
                    return c * c / 2;
                }
                else
                {
                    var s = (A + B + C) / 2;
                    return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
                }
            }
        }

        public bool IsRight
        {
            get
            {
                var abc = new[] { A, B, C }.OrderByDescending(x => x).ToArray();
                return (abc[0] * abc[0]) == (abc[1] * abc[1]) + (abc[2] * abc[2]);
            }
        }

        public Triangle(double a, double b, double c)
        {
            if (!IsTriangleInequalityTheoremSuited(a, b, c))
            {
                throw new Exception("The sum of the lengths of any 2 sides of a triangle must be greater than the third side");
            }

            A = a;
            B = b;
            C = c;
        }

        public static bool IsTriangleInequalityTheoremSuited(double a, double b, double c)
        {
            var sideMustBeGreaterThan0Exception = "Side must be greater than 0";
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException("a", sideMustBeGreaterThan0Exception);
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException("b", sideMustBeGreaterThan0Exception);
            }
            if (c <= 0)
            {
                throw new ArgumentOutOfRangeException("c", sideMustBeGreaterThan0Exception);
            }

            return (c + b > a) && (a + c > b) && (a + b > c);
        }
    }
}
