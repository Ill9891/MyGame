using System;
namespace MyGame
{
    public class Players
    {
       public Skills [] battleNums = new Skills[10];
        string name = null;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Players(string yourName)
        {
            this.name = yourName;
        }
        

        int hp = 12;

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Имя - {name}");
            Console.WriteLine($"Жизнь - {hp}");
            Console.WriteLine($"Урон - {damage}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
