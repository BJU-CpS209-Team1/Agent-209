using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponPistol : Weapon
    {
        public WeaponPistol()
        {
            Cooldown = 10;
            Upgradeable = true;
        }

        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 2; ++i)
            {

                Bullet b = new Bullet(5);

                Random gen = new Random();
                float randX = (float)(gen.NextDouble() * (0.3 - -0.3) + -0.3);
                float randY = (float)(gen.NextDouble() * (0.3 - -0.3) + -0.3);
                dir.X = dir.X + randX;
                dir.Y = dir.Y + randY;

                b.Direction = dir;
                bl.Add(b);
            }
            return bl;
        }

        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return new WeaponPistolShield();
        }

        public override string Serialize() { return "Pistol"; }
    }
}
