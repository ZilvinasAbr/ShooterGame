namespace CommandTest
{
    class Program
    {
        static void Main()
        {
            CommandConsole control = new CommandConsole();
            Enemy enemy = new Enemy();
            ICommand moveEnemy = new MoveCommand(enemy, 100, 100);
            ICommand killEnemy = new KillCommand(enemy);

            // switch on
            control.SetCommand(moveEnemy);
            control.PressButton();

            // switch off
            control.SetCommand(killEnemy);
            control.PressButton();
        }
    }
}
