using System;

namespace Mindbox.Test.AreaCalculation
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public double Area => Math.PI * (Radius * Radius);
        
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new Exception("Radius must be greater than 0");
            }

            Radius = radius;
        }
    }
}
