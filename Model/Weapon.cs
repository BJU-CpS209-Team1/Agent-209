namespace Royale_Platformer.Model
{
    abstract class Weapon
    {
        public float MaxCooldown { get; protected set; }
        public float CurrentCooldown { get; protected set; }
    }
}
