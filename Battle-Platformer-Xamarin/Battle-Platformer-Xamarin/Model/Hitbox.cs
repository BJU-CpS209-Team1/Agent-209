using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    public class Hitbox
    {
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
            Vector2 thisCornerA = thisPos;
            Vector2 thisCornerB = thisPos + Size;

            Vector2 hCornerA = hPos;
            Vector2 hCornerB = hPos + h.Size;

            return !(thisCornerA.X > hCornerB.X || hCornerA.X > thisCornerB.X)
                && !(thisCornerA.Y > hCornerB.Y || hCornerA.Y > thisCornerB.Y);
        }

        public HitSide IntersectsSide(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            Vector2 hTopLeft = hPos;
            Vector2 hBottomRight = hPos + h.Size;

            Vector2 hTopRight = new Vector2(hBottomRight.X, hTopLeft.Y);
            Vector2 hBottomLeft = new Vector2(hTopLeft.X, hBottomRight.Y);

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
            Vector2 thisCornerA = thisPos;
            Vector2 thisCornerB = thisPos + Size;

            return (hPos.X > thisCornerA.X && hPos.X < thisCornerB.X) && (hPos.Y < thisCornerA.Y && hPos.Y > thisCornerB.Y);
        }
    }
}
