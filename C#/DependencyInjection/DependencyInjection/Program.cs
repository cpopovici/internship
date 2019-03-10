using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeapon autoRifle = new AutoRifle(60);
            IWeapon sword = new Sword(45);

            var player = new Player(autoRifle);
            var warrior = new Warrior(sword);
            player.Atack();
            warrior.Atack();

            Console.ReadLine();
        }
    }
}
