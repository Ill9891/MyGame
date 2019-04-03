using System;
namespace MyGame
{
    public class Enemies
    {
       public Skills[] battleNums = new Skills[10];
        string name = "Ork";

        int hp = 10;

        public int HP
        {
            get
            {
                return hp;
            }

            set
            {
                this.hp = value;
            }
        }

        int damage = 2;

        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Имя - {name}");
            Console.WriteLine($"Жизнь - {hp}");
            Console.WriteLine($"Урон - {damage}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
