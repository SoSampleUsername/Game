//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Game
//{
//    class Battle
//    {
//        public Person Character { get; set; }
//        public Person Enemy { get; set; }
//        public Battle(Person character, Person enemy)
//        {
//            Character = character;
//            Enemy = enemy;
//        }

//        public void Fight()
//        {
//            while (Character.Alive && Enemy.Alive)
//            {
//                Random strike_order = new Random();
//                int order = strike_order.Next(1,3);
//                if(order==1)
//                    Character.Hit(Enemy);
//                else
//                    Enemy.Hit(Character);                
//                Character.ShowInfo();
//                Enemy.ShowInfo();
//            }
//        }





//    }
//}



using System;

namespace Game
{
    public class Battle
    {
        public Person Character { get; set; }
        public Person Enemy { get; set; }

        public Battle(Person character, Person enemy)
        {
            Character = character;
            Enemy = enemy;
        }

        public Person Fight()
        {
            while (Character.Alive && Enemy.Alive)
            {
                Character.Hit(Enemy);
                Enemy.Hit(Character);
                Character.ShowInfo();
                Enemy.ShowInfo();
            }
            Console.ReadLine();
            return Character.Alive ? Character : Enemy;
        }
    }
}

