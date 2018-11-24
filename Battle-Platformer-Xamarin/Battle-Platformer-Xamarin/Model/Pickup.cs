using Battle_Platformer_Xamarin.Model;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public abstract class Pickup : WorldObject
    {
        Vector3 position;

        public Pickup()
        {

        }

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

        public abstract Vector2 Deserialize(string serialized);

        // Returns false if the item isn't picked up
        // Ex: Pickup is armor and character already has armor
        public abstract bool PickUp(Character character);

        public string Serialize()
        {
            return $"{this.GetType()},{position.X.ToString()},{position.Y.ToString()},{position.Z.ToString()}";
        }
    }
}
