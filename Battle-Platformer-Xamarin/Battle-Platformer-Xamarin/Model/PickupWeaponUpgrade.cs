using System.Globalization;
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

        public override Vector2 Deserialize(string serialized)
        {
            string[] data = serialized.Split(',');

            float x = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector2(x, y);
        }

        public override bool PickUp(Character character)
        {
            return character.UpgradeWeapon();
        }
    }
}
