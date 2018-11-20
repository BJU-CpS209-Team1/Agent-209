using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    public class Hitbox
    {
        private static readonly float margin = 0.01f;

        public enum HitSide
        {
            Top,
            Bottom,
            Left,
            Right,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            None
        }

        public Vector2 Size { get; set; }

        public Hitbox()
        {
            Size = Vector2.One;
        }

        public bool Intersects(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            /*
            Vector2 thisCornerA = thisPos + (Size / 2);
            Vector2 thisCornerB = thisPos - (Size / 2);

            Vector2 hCornerA = hPos + (h.Size / 2);
            Vector2 hCornerB = hPos - (h.Size / 2);

            return !(thisCornerA.X < hCornerB.X || hCornerA.X < thisCornerB.X)
                && !(thisCornerA.Y > hCornerB.Y || hCornerA.Y > thisCornerB.Y);
            */

            return IntersectsSide(h, thisPos, hPos) != HitSide.None;
        }

        public HitSide IntersectsSide(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            Vector2 hTopRight   = hPos + (h.Size / 2);
            Vector2 hBottomLeft = hPos - (h.Size / 2);

            Vector2 hTopLeft = new Vector2(hBottomLeft.X, hTopRight.Y);
            Vector2 hBottomRight = new Vector2(hTopRight.X, hBottomLeft.Y);

            bool topLeft = Inside(thisPos, hBottomRight);
            bool topRight = Inside(thisPos, hBottomLeft);
            bool bottomLeft = Inside(thisPos, hTopRight);
            bool bottomRight = Inside(thisPos, hTopLeft);

            if (bottomLeft && bottomRight) return HitSide.Bottom;
            if (topLeft && topRight) return HitSide.Top;

            if (topLeft && bottomLeft) return HitSide.Left;
            if (topRight && bottomRight) return HitSide.Right;

            if (topLeft) return HitSide.TopLeft;
            if (topRight) return HitSide.TopRight;
            if (bottomLeft) return HitSide.BottomLeft;
            if (bottomRight) return HitSide.BottomRight;

            return HitSide.None;
        }

        private bool Inside(Vector2 thisPos, Vector2 hPos)
        {
            Vector2 thisCornerA = thisPos + (Size / 2); // Top Right
            Vector2 thisCornerB = thisPos - (Size / 2); // Bottom Left

            return (hPos.X - margin < thisCornerA.X && hPos.X + margin > thisCornerB.X)
                && (hPos.Y - margin < thisCornerA.Y && hPos.Y + margin > thisCornerB.Y);
        }
    }
}
