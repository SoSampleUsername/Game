using System;
using System.Collections.Generic;
using System.Text;
using Game.GameObjects;

namespace Game.GameObjects
{
    public class Sword : Weapon
    {
        public bool Used { get; set; } = false;
        public override void Buff(Weapon obj)
        {
            base.Buff(obj);
            if (obj is Person person)
            {
                person.Damage += 20;
                Used = true;
            }
        }
    }
}