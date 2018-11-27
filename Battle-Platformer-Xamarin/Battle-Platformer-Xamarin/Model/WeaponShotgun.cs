using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponShotgun : Weapon
    {
        public WeaponShotgun()
        {
            Cooldown = 20;
        }

        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 10; ++i)
            {

                Bullet b = new Bullet(1);

                Random gen = new Random();
                float randX = (float) (gen.NextDouble() * (0.3 - 0) + 0);
                float randY = (float) (gen.NextDouble() * (0.3 - 0) + 0);
                dir.X = dir.X + randX;
                dir.Y = dir.Y + randY;

                b.Direction = dir;
                bl.Add(b);
            }
            return bl;
        }


        public override Weapon Upgrade(CharacterClass characterClass)
        {
            throw new System.NotImplementedException();
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }

        public override string Serialize() { return "Shotgun"; }
    }
}
