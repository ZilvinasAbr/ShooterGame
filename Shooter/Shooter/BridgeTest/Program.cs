namespace BridgeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy bigEnemy = new BigEnemy(new BigGun());
            Enemy smallEnemy = new SmallEnemy(new SmallGun());

            bigEnemy.Attack();
            smallEnemy.Attack();
        }
    }
}
