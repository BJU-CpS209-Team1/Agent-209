namespace Royale_Platformer.Model
{
    abstract class Character
    {
        public Weapon HeldWeapon { get; protected set; }
        public bool Armor { get; protected set; }
        public int Health { get; protected set; }
        public int Score { get; protected set; }
    }
}
