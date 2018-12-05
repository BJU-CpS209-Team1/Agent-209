// --------------------
// WeaponPistolShield.cs
// Isaac Abrahamson, Elias Watson
// Advanced Pistol Weapon Class
// --------------------

using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponPistolShield class
    public class WeaponPistolShield : Weapon
    {
        // Create a pistol shield
        public WeaponPistolShield()
        {
            Cooldown = 5;
            Upgradeable = false;
        }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 2; ++i)
            {

                Bullet b = new Bullet(4);

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

        // Method stub for upgrading the weapon
        // <characterClass> is the character's class
        // Returns the upgraded form of the weapon
        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return this;
        }

        public override string Serialize() { return "PistolShield"; }
    }
}
