using Battle_Platformer_Xamarin.Model;

namespace Royale_Platformer.Model
{
    public abstract class Pickup : WorldObject
    {
        // Returns false if the item isn't picked up
        // Ex: Pickup is armor and character already has armor
        public abstract bool PickUp(Character character);
    }
}
