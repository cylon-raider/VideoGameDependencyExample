using System;

namespace VideoGameDependencyExample
{
    internal class Grenade : IWeapon
    {
        public string Name { get; set; }

        public void AttackWithMe()
        {
            Console.WriteLine(Name + " sizzles for a moment and then explodes into a shower of deadly metal fragments!");
        }
    }
}
