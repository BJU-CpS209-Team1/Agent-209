// --------------------
// WeaponAdvancedShotgun.cs
// Isaac Abrahamson, Elias Watson
// Knife Weapon class
// --------------------

using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // WeaponKnife class
    public class WeaponKnife : Weapon
    {
        // Create a knife
        public WeaponKnife()
        {
            Upgradeable = true;
            Cooldown = 50;
        }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
        public override List<Bullet> Fire(Vector2 dir)
        {
            return null;
        }

        // Method stub for upgrading the weapon
        // <characterClass> is the character's class
        // Returns the upgraded form of the weapon
        public override Weapon Upgrade(CharacterClass characterClass)
        {
            switch(characterClass)
            {
                case CharacterClass.Gunner:
                    return new WeaponAR();

                case CharacterClass.Support:
                    return new WeaponShotgun();

                case CharacterClass.Tank:
                    return new WeaponPistol();
            }

            return this;
        }

        // Returns weapon name as a string
        public override string Serialize() {  return "Knife"; }
    }
}
