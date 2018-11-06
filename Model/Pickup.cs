namespace Royale_Platformer.Model
{
    abstract class Pickup
    {
        // Returns false if the item isn't picked up
        // Ex: Pickup is armor and character already has armor
        public abstract bool PickUp(Character character);
    }
}
