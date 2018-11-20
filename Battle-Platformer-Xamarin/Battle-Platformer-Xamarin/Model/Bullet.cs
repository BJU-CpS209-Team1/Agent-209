using Battle_Platformer_Xamarin.Model;
using System;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class Bullet : WorldObject, ISerializer
    {
        public int Damage { get; private set; }

        public Bullet(int damage)
        {
            if (damage < 0)
                throw new Exception("Invalid bullet damage!");
            Damage = damage;
        }

        public Bullet(int damage, Scene scene, Sprite2D sprite, Vector2 pos)
        {
            if (damage < 0)
                throw new Exception("Invalid bullet damage!");
            Damage = damage;

            WorldNode = scene.CreateChild();
            WorldNode.SetPosition2D(pos);
            WorldNode.SetScale(1f / 0.7f);

            StaticSprite2D staticSprite = WorldNode.CreateComponent<StaticSprite2D>();
            staticSprite.BlendMode = BlendMode.Alpha;
            staticSprite.Sprite = sprite;

            WorldHitbox = new Hitbox();
            WorldHitbox.Size = new Vector2(0.3f, 0.3f);
        }

        public string Serialize()
        {
            return "";
        }

        public ISerializer Deserialize(string serialized)
        {
            return new Bullet(0);
        }
    }
}
