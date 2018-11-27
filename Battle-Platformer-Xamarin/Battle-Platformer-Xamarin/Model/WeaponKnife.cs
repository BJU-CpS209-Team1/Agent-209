using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponKnife : Weapon
    {
        public WeaponKnife()
        {
            Upgradeable = true;
        }

        public override List<Bullet> Fire(Vector2 dir)
        {
            return null;
        }

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

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }

        public override string Serialize() {  return "Knife"; }
    }
}
