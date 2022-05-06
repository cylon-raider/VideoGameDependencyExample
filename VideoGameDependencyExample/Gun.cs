using System;
using System.Collections.Generic;

namespace VideoGameDependencyExample
{
    internal class Gun : IWeapon
    {
        public string Name { get; set; }
        public List<Bullet> Bullets { get; set; }

        public void AttackWithMe()
        {
            if (Bullets.Count > 0)
            {
                Console.WriteLine(Name + " fires the round called " + Bullets[0].Name + ". The victim now has a deadly hole in him!");
                Bullets.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("The gun has no bullets. Nothing happens!");
            }

        }
    }
}
