using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    public abstract class WorldObject
    {
        public Node WorldNode { get; set; }
        public Hitbox WorldHitbox { get; set; }

        public bool Collides(WorldObject obj)
        {
            return WorldHitbox.Intersects(obj.WorldHitbox, WorldNode.Position2D, obj.WorldNode.Position2D);
        }
    }
}
