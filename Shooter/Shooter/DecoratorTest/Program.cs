namespace DecoratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle();

            IShape redCircle = new RedShapeDecorator(new Circle());

            IShape redRectangle = new RedShapeDecorator(new Rectangle());

            circle.Draw();

            redCircle.Draw();

            redRectangle.Draw();
        }
    }
}
