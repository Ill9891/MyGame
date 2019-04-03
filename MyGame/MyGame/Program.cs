using System;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            battle.Fight();
            Console.ReadKey();
        }
    }
}
