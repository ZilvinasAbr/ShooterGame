using System;

namespace DecoratorTest
{
    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape: circle");
        }
    }
}
