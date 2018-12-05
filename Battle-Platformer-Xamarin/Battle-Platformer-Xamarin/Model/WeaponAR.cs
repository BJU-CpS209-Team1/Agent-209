// --------------------
// WeaponAR.cs
// Elias Watson
// WeaponAR class
// --------------------

using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponAR class
    public class WeaponAR : Weapon
    {
        // Create an AR
        public WeaponAR()
        {
            Upgradeable = true;
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
                Bullet b = new Bullet(1);
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
            return new WeaponAdvancedAR();
        }

        public override string Serialize() { return "AR"; }
    }
}
