using System;

namespace Game.GameObjects
{
    public class GameObject
    {
        public string Name { get; set; }
        public virtual void Interaction(GameObject obj)
        {
            Console.WriteLine("Interaction: {0} => {1}", Name, obj.Name);
        }
    }
    //public static class Weapon
    //{
    //    public static string Name { get; set; }
    //    public virtual void Buff(Weapon obj)
    //    {
    //        Console.WriteLine("Interaction: {0} => {1}", Weapon.Name, obj.Name);
    //    }
    //}
}