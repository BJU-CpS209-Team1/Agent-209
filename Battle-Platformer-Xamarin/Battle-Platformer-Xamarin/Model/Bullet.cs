// --------------------
// Bullet.cs
// Elias Watson
// Bullet class
// --------------------

using Battle_Platformer_Xamarin.Model;
using System;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    // Bullet class
    // Holds a bullet world object
    public class Bullet : WorldObject, ISerializer
    {
        // The amount of damage the bullet does
        public int Damage { get; private set; }

        // The character that shot the bullet
        public Character Owner { get; set; }

        // The direction vector of the bullet (normalized)
        public Vector2 Direction { get; set; }

        // Creates a new bullet
        // <damage> sets the bullet damage
        public Bullet(int damage)
        {
            if (damage < 0)
                throw new Exception("Invalid bullet damage!");
            Damage = damage;
        }

        // Creates the bullet's world node
        // <scene> is the Urho scene
        // <sprite> is the bullet's sprite
        // <pos> is the starting position of the bullet
        public void CreateNode(Scene scene, Sprite2D sprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.Position = new Vector3(pos);
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
