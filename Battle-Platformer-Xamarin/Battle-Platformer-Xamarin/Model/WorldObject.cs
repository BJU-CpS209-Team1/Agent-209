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
            if (obj == null || obj.WorldNode == null || obj.WorldHitbox == null || WorldNode == null || WorldHitbox == null || obj.WorldNode.IsDeleted || WorldNode.IsDeleted) return false;

            try
            {
                return WorldHitbox.Intersects(obj.WorldHitbox, WorldNode.Position2D, obj.WorldNode.Position2D);
            }
            catch {
                // most likely caused by knife already hitting player
                // so ignore error
                return false;
            }
        }

        public Hitbox.CollisionSide CollidesSide(WorldObject obj)
        {
            if (obj == null || obj.WorldNode == null || obj.WorldHitbox == null || WorldNode == null || WorldHitbox == null || obj.WorldNode.IsDeleted || WorldNode.IsDeleted) return null;

            return WorldHitbox.IntersectsSide(obj.WorldHitbox, WorldNode.Position2D, obj.WorldNode.Position2D);
        }
    }
}
