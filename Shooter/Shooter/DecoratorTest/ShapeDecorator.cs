namespace DecoratorTest
{
    abstract class ShapeDecorator : IShape
    {
        protected IShape DecoratedShape;

        protected ShapeDecorator(IShape decoratedShape)
        {
            DecoratedShape = decoratedShape;
        }

        public virtual void Draw()
        {
            DecoratedShape.Draw();
        }
    }
}
