// --------------------
// WeaponAdvancedShotgun.cs
// Isaac Abrahamson, Elias Watson
// WeaponAdvancedShotgun class
// --------------------

using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponAdvancedShotgun class
    public class WeaponAdvancedShotgun : Weapon
    {
        // Create an advanced shotgun
        public WeaponAdvancedShotgun()
        {
            Cooldown = 15;
            Upgradeable = false;
        }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
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

        // Method stub for upgrading the weapon
        // <characterClass> is the character's class
        // Returns the upgraded form of the weapon
        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return this;
        }

        // Returns weapon name as a string
        public override string Serialize() { return "Advanced Shotgun"; }
    }
}
