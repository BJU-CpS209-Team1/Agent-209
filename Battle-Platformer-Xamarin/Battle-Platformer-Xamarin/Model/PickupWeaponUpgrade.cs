using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class PickupWeaponUpgrade : Pickup
    {
        public PickupWeaponUpgrade() : base()
        {

        }

        public PickupWeaponUpgrade(Scene scene, Sprite2D sprite, Vector2 pos) : base(scene, sprite, pos)
        {
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }

        public override bool PickUp(Character character)
        {
            return character.UpgradeWeapon();
        }
    }
}
