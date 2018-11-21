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

        public Hitbox.CollisionSide Collision { get; protected set; }

        public WorldObject()
        {
            WorldHitbox = new Hitbox();
        }

        public void UpdateCollision(List<WorldObject> objs)
        {
            Collision = new Hitbox.CollisionSide();
            foreach(WorldObject o in objs)
                Collision.Combine(CollidesSide(o));
        }

        public bool Collides(WorldObject obj)
        {
            return WorldHitbox.Intersects(obj.WorldHitbox, WorldNode.Position2D, obj.WorldNode.Position2D);
        }

        public Hitbox.CollisionSide CollidesSide(WorldObject obj)
        {
            return WorldHitbox.IntersectsSide(obj.WorldHitbox, WorldNode.Position2D, obj.WorldNode.Position2D);
        }
    }
}
