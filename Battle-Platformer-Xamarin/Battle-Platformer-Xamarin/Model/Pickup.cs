// --------------------
// Pickup.cs
// Elias Watson, Isaac Abrahamson
// Pickup abstract class
// --------------------

using Battle_Platformer_Xamarin.Model;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    // Pickup abstract class
    // Provides a parent for all pickup classes
    public abstract class Pickup : WorldObject
    {
        // The position of the pickup
        Vector3 position;

        // Create a blank pickup
        public Pickup()
        {
        }

        // Create a pickup
        // <scene> is the Urho scene
        // <sprite> is the pickup's sprite
        // <pos> is the pickup position
        public Pickup(Scene scene, Sprite2D sprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.SetPosition2D(pos);
            position = WorldNode.Position;
            //WorldNode.SetScale(1f / 0.7f);

            StaticSprite2D staticSprite = WorldNode.CreateComponent<StaticSprite2D>();
            staticSprite.BlendMode = BlendMode.Alpha;
            staticSprite.Sprite = sprite;

            WorldHitbox = new Hitbox();
            WorldHitbox.Size = new Vector2(0.5f, 0.5f);
        }

        // Called when loading a saved GameApp
        public abstract Vector2 Deserialize(string serialized);

        // Called when a character trys to pickup the pickup
        // <character> is the character
        // Returns false if the player cannot get the pickup
        public abstract bool PickUp(Character character);

        // Return Pickup information as text
        public string Serialize()
        {
            return $"{this.GetType()},{position.X.ToString()},{position.Y.ToString()},{position.Z.ToString()}";
        }
    }
}
