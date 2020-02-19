using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Runaway
    {

        public Person Agree { get; set; }
        public Person Disagree { get; set; }
        public Runaway(Person agree, Person disagree)
        {
            Agree = agree;
            Disagree = disagree;
        }


    }
}
