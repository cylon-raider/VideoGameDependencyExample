using System;

namespace VideoGameDependencyExample
{
    internal class HeroThatCanUseAnyWeapon : IHero
    {
        public string Name { get; set; }
        public IWeapon MyWeapon { get; set; }

        public void Attack()
        {
            Console.WriteLine(Name + " prepares to attack!");
            MyWeapon.AttackWithMe();
        }
    }
}
