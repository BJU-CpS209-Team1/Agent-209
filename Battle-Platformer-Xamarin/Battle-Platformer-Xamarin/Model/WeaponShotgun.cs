// --------------------
// WeaponShotgun.cs
// Isaac Abrahamson, Elias Watson
// Shotgun Weapon Class
// --------------------

using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponShotgun class
    public class WeaponShotgun : Weapon
    {
        // Create a shotgun
        public WeaponShotgun()
        {
            Cooldown = 20;
            Upgradeable = true;
        }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 5; ++i)
            {

                Bullet b = new Bullet(1);

                Random gen = new Random();
                float randX = (float) (gen.NextDouble() * (0.1 - -0.1) + -0.1);
                float randY = (float) (gen.NextDouble() * (0.1 - -0.1) + -0.1);
                dir.X = dir.X + randX;
                dir.Y = dir.Y + randY;

                b.Direction = dir;
                bl.Add(b);
            }
            return bl;
        }

        // Method stub for upgrading the weapon
        // <characterClass> is the character's class
        // Returns the upgraded form of the weapon
        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return new WeaponAdvancedShotgun();
        }

        // Returns weapon name as a string
        public override string Serialize() { return "Shotgun"; }
    }
}
