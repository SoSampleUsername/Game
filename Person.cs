//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Game
//{
//    class Person
//    {
//        int hp;
//        int id;
//        public int HealthPoint
//        {
//            get
//            {
//                return hp;
//            }
//            set
//            {
//                if (value < 0)
//                {
//                    hp = 0;
//                    Alive = false;
//                }
//                else
//                    hp = value;
//            }
//        }
//        public int Level { get; set; }
//        public int Damage { get; set; }
//        public string Name { get; set; }
//        public int Id { get; set; }
//        public bool Alive { get; set; } = true;

//        public Person(string name, int id)
//        {
//            Name = name;
//            HealthPoint = 100;
//            Level = 1;
//            Damage = 50;
//            this.id = id;
//        }

//        public void LevelUp()
//        {
//            Level++;
//        }
//        public void Hit(Person target)
//        {
//            if (Alive)
//            {
//                Random random = new Random();
//                target.HealthPoint -= random.Next(Damage - 10, Damage + 11);
//                if (target.HealthPoint == 0)
//                        LevelUp();
//            }
//        }
//        public void FoundSmth(int id)
//        {
//            if (id == 1)
//                HealthPoint += 30;

//        }
//        public void ShowInfo()
//        {
//            Console.WriteLine($"Hi, my name is {Name}, hp: {HealthPoint}, dmg: {Damage}, lvl: {Level}");
//        }

//        public void Move(int[,] map, string direction)
//        {
//            int currentPos1 = 0;
//            int currentPos2 = 0;
//            bool find = false;
//            for (int i = 0; i < map.GetLength(0); i++)
//            {
//                for (int k = 0; k < map.GetLength(1); k++)
//                {
//                    if (map[i, k] == id)
//                    {
//                        find = true;
//                        currentPos1 = i;
//                        currentPos2 = k;
//                        map[i, k] = 0;
//                    }
//                }
//            }
//            if (!find)
//            {
//                Console.WriteLine("Can't find Person with id {0}", id);
//                return;
//            }
//            switch (direction)
//            {
//                case "w":
//                    if (currentPos1 >= 1)
//                        currentPos1--;
//                    break;
//                case "s":
//                    if (currentPos1 <= map.GetLength(0) - 2)
//                        currentPos1++;
//                    break;
//                case "d":
//                    if (currentPos2 <= map.GetLength(1) - 2)
//                        currentPos2++;
//                    break;
//                case "a":
//                    if (currentPos2 >= 1)
//                        currentPos2--;
//                    break;
//                default:
//                    break;
//            }
//            map[currentPos1, currentPos2] = id;


//        }

//    }
//}


using System;

using Game.GameObjects;

namespace Game
{
    public class Person : GameObject
    {
        int id;
        int hp;
        public int HealthPoints
        {
            get
            {
                return hp;
            }
            set
            {
                if (value < 0)
                {
                    hp = 0;
                    Alive = false;
                }
                else
                    hp = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        public int Level { get; set; }
        public int Damage { get; set; }
        public bool Alive { get; set; } = true;
        public Map World { get; set; }
        public int Weapon {get;set;}

        public Person(string name, int id)
        {
            Name = name;
            HealthPoints = 100;
            Level = 1;
            Damage = 50;
            this.id = id;
        }

        public void LevelUp()
        {
            Level++;
            HealthPoints += 50;
        }

        public void Hit(Person target)
        {
            if (Alive)
            {
                Random random = new Random();
                target.HealthPoints -= random.Next(Damage - 10, Damage + 11);
                if (target.HealthPoints == 0)
                    LevelUp();
            }
        }

        public void ShowInfo()
        {
            if (Alive)
                Console.WriteLine($"Hi, I'm {Name}, my hp: {HealthPoints}, dmg: {Damage}, lvl: {Level}");
            else
                Console.WriteLine($"{Name} die");
        }

        public override void Interaction(GameObject obj)
        {
            base.Interaction(obj);
            if (obj is Person person)
            {
                Battle newBattle = new Battle(person, this);
                Person winner = newBattle.Fight();
            }
        }

        public Position Move(string direction)
        {
            Position currentPos = World.GetPersonPosition(this);
            Cell currentCell = World.GetCell(currentPos);

            if (currentPos == null)
            {
                Console.WriteLine("Can't find {0}", Name);
                return null;
            }

            switch (direction)
            {
                case "w":
                    if (currentPos.Pos1 >= 1)
                        currentPos.Pos1--;
                    break;
                case "s":
                    if (currentPos.Pos1 <= World.WorldHeight - 2)
                        currentPos.Pos1++;
                    break;
                case "d":
                    if (currentPos.Pos2 <= World.WorldWidth - 2)
                        currentPos.Pos2++;
                    break;
                case "a":
                    if (currentPos.Pos2 >= 1)
                        currentPos.Pos2--;
                    break;
                default:
                    break;
            }
            Cell wantedCell = World.GetCell(currentPos);

            if (wantedCell.IsEmpty())
            {
                currentCell.PersonOnCell = null;
                wantedCell.PersonOnCell = this;
            }
            else if (wantedCell.HeartOnCell != null)
            {
                wantedCell.HeartOnCell.Interaction(this);
                World.Refresh();
            }
            else if (wantedCell.PersonOnCell != null)
            {
                wantedCell.PersonOnCell.Interaction(this);
                World.Refresh();
            }
            return currentPos;
        }
    }
}
