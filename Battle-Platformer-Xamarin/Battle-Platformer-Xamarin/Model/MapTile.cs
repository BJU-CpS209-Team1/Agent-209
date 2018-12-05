// --------------------
// MapTile.cs
// Elias Watson
// MapTile class
// --------------------

using System;
using System.Collections.Generic;
using System.Text;
using Urho;
using Urho.Urho2D;

namespace Battle_Platformer_Xamarin.Model
{
    // MapTile class
    // Holds a map tile
    public class MapTile : WorldObject
    {
        // Create a map tile
        // <pos> is the position of the tile
        public MapTile(Vector2 pos)
        {
            WorldNode = new Node();
            WorldNode.SetPosition2D(pos);

            WorldHitbox = new Hitbox();
        }

        // Create a map tile
        // <scene> is the Urho scene
        // <sprite> is the tile's sprite
        // <pos> is the position of the tile
        public MapTile(Scene scene, Sprite2D sprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.Position = new Vector3(pos);
            WorldNode.SetScale(1f / 0.7f);

            StaticSprite2D nodeSprite = WorldNode.CreateComponent<StaticSprite2D>();
            nodeSprite.Sprite = sprite;

            WorldHitbox = new Hitbox();
            //WorldHitbox.Size = new Vector2(1, 1);
        }
    }
}
