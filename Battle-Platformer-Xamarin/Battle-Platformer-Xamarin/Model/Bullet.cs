using System;

namespace Royale_Platformer.Model
{
    public class Bullet : ISerializer
    {
        public int Damage { get; private set; }

        public Bullet(int damage)
        {
            if (damage < 0)
                throw new Exception("Invalid bullet damage!");
            Damage = damage;
        }

        public string Serialize()
        {
            return "";
        }

        public ISerializer Deserialize(string serialized)
        {
            return new Bullet(0);
        }
    }
}
