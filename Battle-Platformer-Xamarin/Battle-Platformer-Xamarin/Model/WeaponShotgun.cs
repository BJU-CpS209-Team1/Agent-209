using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponShotgun : Weapon
    {
        public override List<Bullet> Fire(Vector2 dir)
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

        public override string Serialize() { return "Shotgun"; }
    }
}
