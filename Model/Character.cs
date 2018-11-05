namespace Royale_Platformer.Model
{
    abstract class Character
    {
        public CharacterClass Class { get; protected set; }
        public Weapon HeldWeapon { get; protected set; }
        public bool Armor { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int Health { get; protected set; }
        public int Score { get; protected set; }

        public abstract void Hit(Bullet bullet);
    }
}
