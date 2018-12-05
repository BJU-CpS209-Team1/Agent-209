// --------------------
// PickupArmor.cs
// Elias Watson, Isaac Abrahamson
// PickupArmor class
// --------------------

using System.Globalization;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    // PickupArmor class
    // Holds an armor pickup
    public class PickupArmor : Pickup
    {
        // Create an empty armor pickup
        public PickupArmor() : base()
        {
        }

        // Create an armor pickup
        // <scene> is the Urho scene
        // <sprite> is the pickup's sprite
        // <pos> is the pickup position
        public PickupArmor(Scene scene, Sprite2D sprite, Vector2 pos) : base(scene, sprite, pos)
        {
        }

        public override Vector2 Deserialize(string serialized)
        {
            string[] data = serialized.Split(',');

            float x = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector2(x, y);
        }

        // Called when a character tries to pickup the armor pickup
        // <character> is the character
        // Returns false if the character already has armor
        public override bool PickUp(Character character)
        {
            if (character.Armor) return false;

            character.Armor = true;
            if (GameApp.Instance.hardcore)
                character.Score += 15;
            else
                character.Score += 10;
            return true;
        }
    }
}
