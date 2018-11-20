using Battle_Platformer_Xamarin.Model;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public abstract class Pickup : WorldObject
    {
        public Pickup(Scene scene, Sprite2D sprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.SetPosition2D(pos);
            WorldNode.SetScale(1f / 0.7f);

            StaticSprite2D staticSprite = WorldNode.CreateComponent<StaticSprite2D>();
            staticSprite.BlendMode = BlendMode.Alpha;
            staticSprite.Sprite = sprite;
        }

        // Returns false if the item isn't picked up
        // Ex: Pickup is armor and character already has armor
        public abstract bool PickUp(Character character);
    }
}
