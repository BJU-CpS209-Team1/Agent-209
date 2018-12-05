using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponAdvancedAR : Weapon
    {
        public WeaponAdvancedAR()
        {
            Cooldown = 1;
            Upgradeable = false;
        }

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

        public override Weapon Upgrade(CharacterClass characterClass)
        {
            return this;
        }

        public override string Serialize() { return "Advanced AR"; }
    }
}
