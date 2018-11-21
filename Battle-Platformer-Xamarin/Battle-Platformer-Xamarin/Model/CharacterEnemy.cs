using Battle_Platformer_Xamarin.Model;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class CharacterEnemy : Character
    {
        public CharacterEnemy(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            MoveSpeed = 10;
        }

        public override void Update(float deltatime)
        {
            bool onGround = (Collision == Hitbox.HitSide.Bottom
                || Collision == Hitbox.HitSide.BottomLeft
                || Collision == Hitbox.HitSide.BottomRight);

            bool onLeft = (Collision == Hitbox.HitSide.Left
                || Collision == Hitbox.HitSide.TopLeft);

            bool onRight = (Collision == Hitbox.HitSide.Right
                || Collision == Hitbox.HitSide.TopRight);

        }

        public ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
