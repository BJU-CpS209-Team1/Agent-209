using System.Collections.Generic;

namespace Royale_Platformer.Model
{
    class WeaponShotgun : Weapon
    {
        public override List<Bullet> Fire()
        {
            throw new System.NotImplementedException();
        }


        public override Weapon Upgrade(CharacterClass characterClass)
        {
            throw new System.NotImplementedException();
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
