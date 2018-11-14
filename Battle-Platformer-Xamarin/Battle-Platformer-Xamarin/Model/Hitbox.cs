using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.Model
{
    public class Hitbox
    {
        public Vector2 Size { get; set; }

        public bool Intersects(Hitbox h, Vector2 thisPos, Vector2 hPos)
        {
            Vector2 thisCornerA = thisPos;
            Vector2 thisCornerB = thisPos + Size;

            Vector2 hCornerA = hPos;
            Vector2 hCornerB = hPos + h.Size;

            return !(thisCornerA.X > hCornerB.X || hCornerA.X > thisCornerB.X)
                && !(thisCornerA.Y > hCornerB.Y || hCornerA.Y > thisCornerB.Y);
        }
    }
}
