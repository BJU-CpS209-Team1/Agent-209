// --------------------
// Hitbox.cs
// Elias Watson
// Hitbox class, CollisionSide class
// --------------------

using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    // Hitbox class
    // Holds a hitbox
    // Provides methods to find collisions between hitboxes
    public class Hitbox
    {
        // Margin of error
        private static readonly float margin = 0.0f;

        // CollisionSide class
        // Holds the state of a collision between hitboxes
        public class CollisionSide
        {
            // If top left corner is touching another hitbox
            public bool TopLeft { get; set; }

            // If top right corner is touching another hitbox
            public bool TopRight { get; set; }

            // If bottom left corner is touching another hitbox
            public bool BottomLeft { get; set; }

            // If bottom right corner is touching another hitbox
            public bool BottomRight { get; set; }

            // If top middle is touching another hitbox
            public bool TopMiddle { get; set; }

            // If bottom middle is touching another hitbox
            public bool BottomMiddle { get; set; }

            // If left middle is touching another hitbox
            public bool LeftMiddle { get; set; }

            // If right middle is touching another hitbox
            public bool RightMiddle { get; set; }

            // If there is a wall to the left of the bottom of the hitbox
            public bool WallLeft { get; set; }

            // If there is a wall to the right of the bottom of the hitbox
            public bool WallRight { get; set; }

            // Are any of the points touching another hitbox
            public bool Any
            {
                get
                {
                    return TopLeft    || TopRight
                        || BottomLeft || BottomRight
                        || TopMiddle  || BottomMiddle
                        || LeftMiddle || RightMiddle
                        || WallLeft   || WallRight;
                }
            }

            // Combine two CollisionSide objects
            // <c> is the other CollisionSide object
            public void Combine(CollisionSide c)
            {
                TopLeft      |= c.TopLeft;
                TopRight     |= c.TopRight;
                BottomLeft   |= c.BottomLeft;
                BottomRight  |= c.BottomRight;
                TopMiddle    |= c.TopMiddle;
                BottomMiddle |= c.BottomMiddle;
                LeftMiddle   |= c.LeftMiddle;
                RightMiddle  |= c.RightMiddle;
                WallLeft     |= c.WallLeft;
                WallRight    |= c.WallRight;
            }
        }

        // The dimensions of the hitbox
        public Vector2 Size { get; set; }

        // Create a hitbox with dimensions (1, 1)
        public Hitbox()
        {
            Size = Vector2.One;
        }

        // Returns if two hitboxes have collided
        // <h> is the other hitbox
        // <thisPos> is the position of the current hitbox
        // <hPos> is the position of the other hitbox
        public bool Intersects(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            return IntersectsSide(h, thisPos, hPos).Any;
        }

        // Find the points that two hitboxes collide
        // <h> is the other hitbox
        // <thisPos> is the current hitbox's position
        // <hPos> is the other hitbox's position
        // Returns a CollisionSide object with the results
        public CollisionSide IntersectsSide(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            Vector2 topRight    = thisPos + (Size / 2);
            Vector2 bottomLeft  = thisPos - (Size / 2);
            Vector2 topLeft     = new Vector2(bottomLeft.X, topRight.Y);
            Vector2 bottomRight = new Vector2(topRight.X, bottomLeft.Y);

            Vector2 middleTop    = (topLeft    + topRight)    / 2;
            Vector2 middleBottom = (bottomLeft + bottomRight) / 2;
            Vector2 middleLeft   = (topLeft    + bottomLeft)  / 2;
            Vector2 middleRight  = (topRight   + bottomRight) / 2;

            Vector2 wallLeft  = (bottomLeft)  + new Vector2(0f, 0.1f);
            Vector2 wallRight = (bottomRight) + new Vector2(0f, 0.1f);

            CollisionSide collisionSide = new CollisionSide();

            collisionSide.TopLeft     = Inside(h, hPos, topLeft);
            collisionSide.TopRight    = Inside(h, hPos, topRight);
            collisionSide.BottomLeft  = Inside(h, hPos, bottomLeft);
            collisionSide.BottomRight = Inside(h, hPos, bottomRight);

            collisionSide.TopMiddle    = Inside(h, hPos, middleTop);
            collisionSide.BottomMiddle = Inside(h, hPos, middleBottom);
            collisionSide.LeftMiddle   = Inside(h, hPos, middleLeft);
            collisionSide.RightMiddle  = Inside(h, hPos, middleRight);

            collisionSide.WallLeft  = Inside(h, hPos, wallLeft);
            collisionSide.WallRight = Inside(h, hPos, wallRight);

            return collisionSide;
        }

        // Check if a point is within a hitbox
        // <h> is the hitbox
        // <hPos> is the hitbox's position
        // <point> is the point
        private static bool Inside(Hitbox h, Vector2 hPos, Vector2 point)
        {
            Vector2 cornerA = hPos + (h.Size / 2); // Top Right
            Vector2 cornerB = hPos - (h.Size / 2); // Bottom Left

            return (point.X - margin < cornerA.X && point.X + margin > cornerB.X)
                && (point.Y - margin < cornerA.Y && point.Y + margin > cornerB.Y);
        }
    }
}
