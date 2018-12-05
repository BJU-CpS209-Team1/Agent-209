// --------------------
// PickupWeaponUpgrade.cs
// Elias Watson, Isaac Abrahamson
// PickupWeaponUpgrade class
// --------------------

using System.Globalization;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    // PickupWeaponUpgrade class
    // Holds a weapon upgrade pickup
    public class PickupWeaponUpgrade : Pickup
    {
        // Create a blank weapon upgrade pickup
        public PickupWeaponUpgrade() : base()
        {
        }

        // Create a weapon upgrade pickup
        // <scene> is the Urho scene
        // <sprite> is the pickup's sprite
        // <pos> is the pickup position
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

        // Called when a character tries to pickup the weapon upgrade pickup
        // <character> is the character
        // Returns false if the character already has the max level weapon
        public override bool PickUp(Character character)
        {
             return character.UpgradeWeapon();
        }
    }
}
