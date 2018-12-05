// --------------------
// Weapon.cs
// Isaac Abrahamson, Elias Watson
// Weapon class
// --------------------

using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    // Weapon class
    // Provides a parent for weapon classes
    public abstract class Weapon
    {
        // Is the weapon upgradeable
        public bool Upgradeable { get; protected set; }

        // The weapon's cooldown
        public float MaxCooldown { get; protected set; }

        // The weapon's current cooldown time left
        public float CurrentCooldown { get; protected set; }

        // The weapon's current cooldown time left
        public int Cooldown { get; set; }

        // Method stub for firing the weapon
        // <dir> is the direction the character is firing
        // Returns a list of bullets
        public abstract List<Bullet> Fire(Vector2 dir);

        // Method stub for upgrading the weapon
        // <characterClass> is the character's class
        // Returns the upgraded form of the weapon
        public abstract Weapon Upgrade(CharacterClass characterClass);

        // Convert data into text data
        public abstract string Serialize();

        // Method for retreiving the class of a weapon
        // Takes a serialized name of a weapon as type
        public static Weapon GetWeaponType(string type)
        {
            switch (type)
            {
                case "Knife":
                    return new WeaponKnife();
                case "AR":
                    return new WeaponAR();
                case "AdvancedAR":
                    return new WeaponAdvancedAR();
                case "Shotgun":
                    return new WeaponShotgun();
                case "AdvancedShotgun":
                    return new WeaponAdvancedShotgun();
                case "Pistol":
                    return new WeaponPistol();
                case "PistolShield":
                    return new WeaponPistolShield();
                default:
                    return new WeaponKnife();
            }
        }
    }
}
