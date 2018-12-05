using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponAdvancedShotgun : Weapon
    {
        public WeaponAdvancedShotgun()
        {
            Cooldown = 15;
            Upgradeable = false;
        }

        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 10; ++i)
            {

                Bullet b = new Bullet(1);

                Random gen = new Random();
                float randX = (float)(gen.NextDouble() * (0.05 - -0.05) + -0.05);
                float randY = (float)(gen.NextDouble() * (0.05 - -0.05) + -0.05);
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

        public override string Serialize() { return "Advanced Shotgun"; }
    }
}
