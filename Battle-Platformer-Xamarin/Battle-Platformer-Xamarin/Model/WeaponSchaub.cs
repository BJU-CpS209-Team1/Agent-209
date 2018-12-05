// --------------------
// WeaponSchaub.cs
// Isaac Abrahamson
// Schaub Mode Weapon Class
// --------------------

using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponSchaub class
    public class WeaponSchaub : Weapon
    {
        // Create a Schaub weapon
        public WeaponSchaub()
        {
            Cooldown = 5;
        }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
        public override List<Bullet> Fire(Vector2 dir)
        {
            List<Bullet> bl = new List<Bullet>();
            for (int i = 0; i < 1; ++i)
            {
                Bullet b = new Bullet(100);
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
            throw new System.NotImplementedException();
        }

        // Returns weapon name as a string
        public override string Serialize() { return "Schaub"; }
    }
}
