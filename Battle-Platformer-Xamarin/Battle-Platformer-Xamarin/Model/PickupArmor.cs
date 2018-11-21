using System.Globalization;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class PickupArmor : Pickup
    {
        public PickupArmor() : base()
        {

        }

        public PickupArmor(Scene scene, Sprite2D sprite, Vector2 pos) : base(scene, sprite, pos)
        {
        }

        public override Vector2 Deserialize(string serialized)
        {
            string[] coords = serialized.Split(',');

            float x = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector2(x, y);
        }

        public override bool PickUp(Character character)
        {
            if (character.Armor) return false;

            character.Armor = true;
            return true;
        }
    }
}
