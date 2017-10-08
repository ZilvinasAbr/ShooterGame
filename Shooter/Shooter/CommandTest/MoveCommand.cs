namespace CommandTest
{
    class MoveCommand : ICommand
    {
        private readonly Enemy _enemy;
        private readonly int _x, _y;

        public MoveCommand(Enemy enemy, int x, int y)
        {
            _enemy = enemy;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _enemy.Move(_x, _y);
        }
    }
}
