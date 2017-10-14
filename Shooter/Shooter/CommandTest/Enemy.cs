using System;

namespace CommandTest
{
    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Move(int x, int y)
        {
            Console.WriteLine($"Move {x} and {y}");
        }

        public virtual void Die()
        {
            Console.WriteLine("Enemy died");
        }
    }
}
