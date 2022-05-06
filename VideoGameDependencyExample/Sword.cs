using System;

namespace VideoGameDependencyExample
{
    internal class Sword : IWeapon
    {
        public string SwordName { get; set; }

        public void AttackWithMe()
        {
            Console.WriteLine(SwordName + " slices through the air, devastating all enemies");
        }
    }
}
