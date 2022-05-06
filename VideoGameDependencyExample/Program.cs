using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace VideoGameDependencyExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HeroThatOnlyUsesSwords hero1 = new HeroThatOnlyUsesSwords { Name = "Ultraman" };
            hero1.Attack();

            HeroThatCanUseAnyWeapon hero2 = new HeroThatCanUseAnyWeapon { Name = "Eregon", MyWeapon = new Sword { SwordName = "Brisinger" } };

            hero2.Attack();
            Console.WriteLine();

            HeroThatCanUseAnyWeapon hero3 = new HeroThatCanUseAnyWeapon { Name = "The Joker", MyWeapon = new Grenade { Name = "The Pineapple" } };
            hero3.Attack();
            Console.WriteLine();

            HeroThatCanUseAnyWeapon hero4 = new HeroThatCanUseAnyWeapon
            {
                Name = "GI Joe",
                MyWeapon = new Gun
                {
                    Name = "Six Shooter",
                    Bullets = new List<Bullet>
                    {
                            new Bullet { Name = "Silver Slug", GramsOfPowder = 10 },
                            new Bullet { Name = "Lead Ball", GramsOfPowder = 20 },
                            new Bullet { Name = "Rusty Nail", GramsOfPowder = 3 },
                            new Bullet { Name = "Hollow Point", GramsOfPowder = 10 },



                    }
                }
            };

            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();

            // configuration file
            // in asp.net this section usually sits in a separate config file like startup.cs
            // we will notify the contents of this startup section

            //servicecollection is the "container" of all registered dependencies

            ServiceCollection services = new ServiceCollection();

            // all new weapons will now be set to grenades by default


            //services.AddTransient<IWeapon, Grenade>(grenade => new Grenade { Name = "Exploding Pen" });
            services.AddTransient<IWeapon, Gun>(gun => new Gun
            {
                Name = "Six Shooter",
                Bullets = new List<Bullet>
                    {
                            new Bullet { Name = "Silver Slug", GramsOfPowder = 10 },
                            new Bullet { Name = "Lead Ball", GramsOfPowder = 20 },
                            new Bullet { Name = "Rusty Nail", GramsOfPowder = 3 },
                            new Bullet { Name = "Hollow Point", GramsOfPowder = 10 },

                    }
            });


            // all new heros will be "Johnny" by default
            services.AddTransient<IHero, HeroThatCanUseAnyWeapon>(hero => new HeroThatCanUseAnyWeapon { Name = "Johnny English", MyWeapon = hero.GetService<IWeapon>() });

            // a "compile" step to assemble everything defined above
            ServiceProvider provider = services.BuildServiceProvider();

            // implement
            var hero5 = provider.GetService<IHero>();

            // test
            hero5.Attack();


            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
