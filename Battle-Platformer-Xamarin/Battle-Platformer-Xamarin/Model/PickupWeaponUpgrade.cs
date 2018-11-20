using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class PickupWeaponUpgrade : Pickup
    {
        public PickupWeaponUpgrade(Scene scene, Sprite2D sprite, Vector2 pos) : base(scene, sprite, pos)
        {
        }

        public override bool PickUp(Character character)
        {
            throw new System.NotImplementedException();
        }
    }
}
