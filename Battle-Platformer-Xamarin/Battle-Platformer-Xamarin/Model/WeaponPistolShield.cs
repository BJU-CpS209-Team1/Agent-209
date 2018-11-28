using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponPistolShield : Weapon
    {
        public WeaponPistolShield()
        {
            Cooldown = 5;
            Upgradeable = false;
        }

        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 2; ++i)
            {

                Bullet b = new Bullet(3);

                Random gen = new Random();
                float randX = (float)(gen.NextDouble() * (0.1 - -0.1) + -0.1);
                float randY = (float)(gen.NextDouble() * (0.1 - -0.1) + -0.1);
                dir.X = dir.X + randX;
                dir.Y = dir.Y + randY;

                b.Direction = dir;
                bl.Add(b);
            }
            return bl;
        }

        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return this;
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }

        public override string Serialize() { return "PistolShield"; }
    }
}
