using System;

namespace VideoGameDependencyExample
{
    internal class HeroThatOnlyUsesSwords
    {
        public string Name { get; set; }

        public void Attack()
        {
            // doing it wrong without using DI
            // when you see a new object in a class, you have just created a strong
            // dependency. In this case, because we instantiate a sword inside the hero class,
            // the hero cannot exist without his sword

            Sword sword = new Sword { SwordName = "Excalibur" };
            Console.WriteLine(Name + " prepares himself for the battle");
            sword.AttackWithMe();

        }
    }
}
