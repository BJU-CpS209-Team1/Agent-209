namespace Royale_Platformer.Model
{
    abstract class Character
    {
        public CharacterClass Class { get; protected set; }
        public Weapon HeldWeapon { get; protected set; }
        public bool Armor { get; set; }
        public int MaxHealth { get; protected set; }
        public int Health { get; protected set; }
        public int Score { get; protected set; }

        public Character(CharacterClass characterClass, int maxHealth)
        {
            Class = characterClass;
            // TODO: Set HeldWeapon
            Armor = false;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Score = 0;
        }

        public abstract void Hit(Bullet bullet);
        public abstract Character Deserialize();

        public string Serialize()
        {
            return "";
        }

    }
}
