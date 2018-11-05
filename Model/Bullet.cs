namespace Royale_Platformer.Model
{
    class Bullet
    {
        public int Damage { get; private set; }

        public Bullet(int damage)
        {
            Damage = damage;
        }

        public string Serialize() {
          return "";
        }

        public Bullet Serialize() {
          return new Bullet();
        }
    }
}
