using System;
using System.Threading;

namespace MyGame
{
    public class Battle
    {
        Players player = null;
        Enemies enemy = null;

        private void PrepareToFight()
        {
            this.enemy = new Enemies();
            Console.Write("Введите имя вашего персонажа и нажмите Enter: ");
            string nam = Console.ReadLine();
            Console.Clear();
            this.player = new Players(nam);
            Console.WriteLine("Приветствуем тебя " + player.Name);
            Console.WriteLine("В этой игре вы поочередно бросаете кубик, значение могут выпасть от 1 до 10.");
            Console.WriteLine("У вас имеется 10 пустых ячеек соотвественно. Если значение кубика совпадает с пустой ячейкой, то вы наносити свой базовый урон.");
            Console.WriteLine("Если значение совпадает с ячейкой в которую вы поместили умение, то наносится урон от умения.");
            Console.WriteLine("Начнем же бой! Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();

        }

        public void Fight()
        {
            Random random = new Random();
            int roll;
            int enemySkill;

            PrepareToFight();

            Console.WriteLine("Расположите умение! Для этого введите цифру от 1 до 10 (цифра ячейки) и нажмите Enter:\n");
            int skill = int.Parse(Console.ReadLine());
            player.battleNums[skill - 1] = new Skills("Backstab", 4);
            Console.WriteLine("Ваш " + player.battleNums[skill - 1].name + " под цифрой " + skill);
            enemySkill = random.Next(1, 11);
            enemy.battleNums[enemySkill - 1] = new Skills("Smash", 7);
            Console.WriteLine("\nВражеский " + enemy.battleNums[enemySkill - 1].name + " под цифрой " + enemySkill);
            Console.WriteLine("\nНажмите любую клавишу что бы начать бой!");
            Console.ReadKey();
            Console.Clear();

            while (player.HP > 0 || enemy.HP > 0)
            { 

                player.Show();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(player.battleNums[skill - 1].name + " в ячейке номер " + skill + " с уроном " + player.battleNums[skill - 1].damage);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nпротив\n");
                enemy.Show();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.battleNums[enemySkill - 1].name + " в ячейке номер " + enemySkill + " с уроном " + enemy.battleNums[enemySkill - 1].damage);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\nНажмите клавишу R на английской раскладке что бы совершить бросок кубика. ");

                string rollDice = Console.ReadLine();
                if (rollDice == "R")
                {
                    roll = random.Next(1, 11);

                    Console.Clear();
                    Console.WriteLine("Вы выкинули " + roll);
                    if (player.battleNums[roll-1] == null)
                    {
                        enemy.HP -= player.Damage;
                        Console.WriteLine("\nВы нанесли врагу " + player.Damage + " урона!");
                    }
                    else
                    {
                        enemy.HP -= player.battleNums[roll-1].damage;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nВы нанесли врагу " + player.battleNums[roll-1].damage + " урона с помощью " + player.battleNums[roll - 1].name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Thread.Sleep(1000);
                    Console.WriteLine("\nБросает враг...\n");
                    roll = random.Next(1, 11);
                    Thread.Sleep(1000);
                    Console.WriteLine("Враг выкинул " + roll);
                    if (enemy.battleNums[roll-1] == null)
                    {
                        player.HP -= enemy.Damage;
                        Console.WriteLine("\nВы нанесли врагу " + enemy.Damage + " урона!");
                    }
                    else
                    {
                        player.HP -= enemy.battleNums[roll-1].damage;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nВраг нанес вам " + enemy.battleNums[roll-1].damage + " урона с помощью " + enemy.battleNums[roll - 1].name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                    
                }
                if (player.HP <= 0 || enemy.HP <= 0)
                {
                    break;
                }
            } 


            if (enemy.HP <= 0)
            {
                Console.WriteLine("Вы победили!");
            }
            else if (player.HP <= 0)
            {
                Console.WriteLine("Вы проиграли!");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}
