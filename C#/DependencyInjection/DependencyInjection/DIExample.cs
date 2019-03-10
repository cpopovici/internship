using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public interface IWeapon
    {
        void Atack();
    }

    public class AutoRifle : IWeapon
    {
        public int Damage { get; }

        public AutoRifle(int damage)
        {
            this.Damage = damage;
        }

        public void Atack()
        {
            Console.WriteLine($"Using {nameof(AutoRifle)} for ATACK! PEW PEW! {Damage} DMG");
        }
    }

    public class Sword : IWeapon
    {
        public int Damage { get; }

        public Sword(int damage)
        {
            this.Damage = damage;
        }

        public void Atack()
        {
            Console.WriteLine($"Using {nameof(Sword)} for ATACK! Chuck-Chuck! {Damage} DMG");
        }
    }

    public class Player
    {
        private readonly IWeapon Weapon;

        public Player(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void Atack()
        {
            Weapon?.Atack();
        }
    }

    public class Warrior
    {
        private readonly IWeapon Weapon;

        public Warrior(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void Atack()
        {
            Weapon?.Atack();
        }
    }
}
