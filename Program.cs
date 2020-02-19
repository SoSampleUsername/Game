//using System;

//namespace Game
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string name = "Warrior";
//            Person pers = new Person(name,1);
//            Person enemy1 = new Person("Enemy 1",2);



//            pers.ShowInfo();
//            enemy1.ShowInfo();

//            //Battle b = new Battle(pers, enemy1);
//            //b.Fight();
//            int[,] map = new int[10, 14];
//            map[1, 1] = pers.Id;
//            map[3, 3] = enemy1.Id;
//            map[3, 5] = -1;


//            while(pers.Alive)
//            { 
//                pers.Move(map, Console.ReadKey().KeyChar.ToString());
//                Console.Clear();
//                pers.ShowInfo();
//                ShowMap(map);
//            }
//            Console.WriteLine("Game Over");

//            static void ShowMap(int[,] map)
//            {
//                for (int i = 0; i < map.GetLength(0); i++)
//                {
//                    //for (int g = 0; g < map.GetLength(1); g++) Console.Write("__");
//                    //Console.WriteLine("_");
//                    for (int k = 0; k < map.GetLength(1); k++)
//                    {
//                        ToConsoleWrite("|", ConsoleColor.Green);
//                        if (map[i, k] == 1)
//                            ToConsoleWrite("P", ConsoleColor.Cyan);
//                        else if (map[i, k] > 1)
//                            ToConsoleWrite("E", ConsoleColor.Red);
//                        else if (map[i, k] == -1)
//                            ToConsoleWrite("♥", ConsoleColor.Red);
//                        else
//                            ToConsoleWrite(" ");
//                    }
//                    ToConsole("|", ConsoleColor.Green);
//                }


//            }
//            static void ToConsoleWrite(string str, ConsoleColor color = ConsoleColor.White)
//            {
//                Console.ForegroundColor = color;
//                Console.Write(str);
//                Console.ResetColor();
//            }

//            static void ToConsole(string str, ConsoleColor color = ConsoleColor.White)
//            {
//                Console.ForegroundColor = color;
//                Console.WriteLine(str);
//                Console.ResetColor();
//            }



//        }
//    }
//}


using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string name = "Player";
            Person pers = new Person(name, 1);
            Person enemy1 = new Person("Enemy 1", 2);
            Person enemy2 = new Person("Enemy 1", 2);
            Person enemy3 = new Person("Enemy 1", 2);
            Person enemy4 = new Person("Enemy 1", 2);
            Person enemy5 = new Person("Enemy 1", 2);

            Map world = new Map(10, 14);
            world.GenerateMap();

            world.InitPerson(pers, 1, 1);
            world.InitPerson(enemy1, 3, 3);
            world.InitPerson(enemy2, 3, 5);
            world.InitPerson(enemy3, 5, 3);
            world.InitPerson(enemy4, 1, 3);
            world.InitPerson(enemy5, 1, 4);

            while (pers.Alive)
            {
                Console.Clear();
                pers.ShowInfo();
                world.Show();
                Position wantedPos = pers.Move(Console.ReadKey().KeyChar.ToString());
            }
            Console.WriteLine("Game over");
        }
    }
}