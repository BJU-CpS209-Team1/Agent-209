using System.Collections.Generic;

namespace Royale_Platformer.Model
{
    abstract class Weapon
    {
        public bool Upgradeable { get; protected set; }
        public float MaxCooldown { get; protected set; }
        public float CurrentCooldown { get; protected set; }

        public abstract List<Bullet> Fire();
        public abstract Weapon Upgrade(CharacterClass characterClass);
        public abstract Weapon Deserialize(string serialized);

        public string Serialize() {
          return "";
        }

    }
}
