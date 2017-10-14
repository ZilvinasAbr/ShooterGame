namespace BridgeTest
{
    abstract class Enemy
    {
        protected IGun Gun;

        protected Enemy(IGun gun)
        {
            Gun = gun;
        }

        public abstract void Attack();
    }
}
