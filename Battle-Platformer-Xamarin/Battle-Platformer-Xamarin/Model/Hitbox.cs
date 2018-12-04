using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    public class Hitbox
    {
        private static readonly float margin = 0.0f;

        public class CollisionSide
        {
            public bool TopLeft { get; set; }
            public bool TopRight { get; set; }
            public bool BottomLeft { get; set; }
            public bool BottomRight { get; set; }

            public bool TopMiddle { get; set; }
            public bool BottomMiddle { get; set; }
            public bool LeftMiddle { get; set; }
            public bool RightMiddle { get; set; }

            public bool WallLeft { get; set; }
            public bool WallRight { get; set; }

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

        public Vector2 Size { get; set; }

        public Hitbox()
        {
            Size = Vector2.One;
        }

        public bool Intersects(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            return IntersectsSide(h, thisPos, hPos).Any;
        }

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

        private static bool Inside(Hitbox h, Vector2 hPos, Vector2 point)
        {
            Vector2 cornerA = hPos + (h.Size / 2); // Top Right
            Vector2 cornerB = hPos - (h.Size / 2); // Bottom Left

            return (point.X - margin < cornerA.X && point.X + margin > cornerB.X)
                && (point.Y - margin < cornerA.Y && point.Y + margin > cornerB.Y);
        }
    }
}
