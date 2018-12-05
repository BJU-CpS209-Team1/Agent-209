// --------------------
// WeaponPistol.cs
// Elias Watson
// WeaponPistol class
// --------------------

using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponPistol class
    public class WeaponPistol : Weapon
    {
        // Create a pistol
        public WeaponPistol()
        {
            Cooldown = 10;
            Upgradeable = true;
        }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
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

        // Method stub for upgrading the weapon
        // <characterClass> is the character's class
        // Returns the upgraded form of the weapon
        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return new WeaponPistolShield();
        }

        public override string Serialize() { return "Pistol"; }
    }
}
