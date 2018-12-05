// --------------------
// WorldObject.cs
// Elias Watson
// WorldObject class
// --------------------

using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    // WorldObject class
    public abstract class WorldObject
    {
        // The object's Urho node
        public Node WorldNode { get; set; }

        // The object's hitbox
        public Hitbox WorldHitbox { get; set; }

        // The object's collision state
        public Hitbox.CollisionSide Collision { get; protected set; }

        // Create a world object
        public WorldObject()
        {
            WorldHitbox = new Hitbox();
        }

        // Update the collision state
        // <objs> list of world objects to check collisions with
        public void UpdateCollision(List<WorldObject> objs)
        {
            Collision = new Hitbox.CollisionSide();
            foreach(WorldObject o in objs)
                Collision.Combine(CollidesSide(o));
        }

        // Checks if the object collides with another object
        // <obj> is the other world object
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

        // Get the collision state with another world object
        // <obj> the other world object
        public Hitbox.CollisionSide CollidesSide(WorldObject obj)
        {
            if (obj == null || obj.WorldNode == null || obj.WorldHitbox == null || WorldNode == null || WorldHitbox == null || obj.WorldNode.IsDeleted || WorldNode.IsDeleted) return null;

            return WorldHitbox.IntersectsSide(obj.WorldHitbox, WorldNode.Position2D, obj.WorldNode.Position2D);
        }
    }
}
