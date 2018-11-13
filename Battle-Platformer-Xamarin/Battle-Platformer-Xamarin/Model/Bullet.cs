namespace Royale_Platformer.Model
{
    public class Bullet : ISerializer
    {
        public int Damage { get; private set; }

        public Bullet(int damage)
        {
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
