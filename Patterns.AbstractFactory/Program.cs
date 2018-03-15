using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();

            Console.ReadLine();
        }
    }
    abstract class Weapon
    {
        public abstract void Hit();
    }
    abstract class Movement
    {
        public abstract void Move();
    }
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Shot from Arbalet");
        }
    }
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Hit Sword");
        }
    }
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Fly");
        }
    }
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Run");
        }
    }
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
