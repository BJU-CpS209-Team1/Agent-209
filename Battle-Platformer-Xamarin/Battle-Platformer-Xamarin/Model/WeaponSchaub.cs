// --------------------
// WeaponSchaub.cs
// Isaac Abrahamson
// Schaub Mode Weapon Class
// --------------------

using System.Collections.Generic;
using Urho;

namespace Royale_Platformer.Model
{
    public class WeaponSchaub : Weapon
    {
        public WeaponSchaub()
        {
            Cooldown = 5;
        }

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

        public override Weapon Upgrade(CharacterClass characterClass)
        {
            throw new System.NotImplementedException();
        }

        public override string Serialize() { return "Schaub"; }
    }
}
