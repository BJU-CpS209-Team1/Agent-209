using System;
using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public abstract class Weapon : ISerializer
    {
        public bool Upgradeable { get; protected set; }
        public float MaxCooldown { get; protected set; }
        public float CurrentCooldown { get; protected set; }
        public int Cooldown { get; set; }

        public abstract List<Bullet> Fire(Vector2 dir);
        public abstract Weapon Upgrade(CharacterClass characterClass);
        public abstract ISerializer Deserialize(string serialized);

        public abstract string Serialize();

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
