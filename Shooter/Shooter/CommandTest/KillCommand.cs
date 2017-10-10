using System;

namespace CommandTest
{
    class KillCommand : ICommand
    {
        private readonly Enemy _enemy;

        public KillCommand(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Execute()
        {
            _enemy.Die();
        }
    }
}
