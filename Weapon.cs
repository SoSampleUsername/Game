using System;

namespace Game.GameObjects
{
    public class Weapon
    {
        public string Name { get; set; }
        public virtual void Buff(Weapon obj)
        {
            Console.WriteLine("Interaction: {0} => {1}", Name, obj.Name);
        }
    }
}