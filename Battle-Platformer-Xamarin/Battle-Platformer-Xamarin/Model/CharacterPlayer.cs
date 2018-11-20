using Urho;
using Urho.Urho2D;
using Battle_Platformer_Xamarin.Model;

namespace Royale_Platformer.Model
{
    public class CharacterPlayer : Character
    {
        public struct PlayerInput
        {
            public bool W, A, S, D;
            public bool Space, LastSpace;
        }

        public PlayerInput Input;

        public CharacterPlayer(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            Input = new PlayerInput();
            MoveSpeed = 10;
        }

        public override void Update(float deltatime)
        {
            bool onGround = (Collision == Hitbox.HitSide.Bottom
                || Collision == Hitbox.HitSide.BottomLeft
                || Collision == Hitbox.HitSide.BottomRight);

            Velocity.X = 0;

            if (Input.A) Velocity.X -= MoveSpeed * 100 * deltatime;
            if (Input.D) Velocity.X += MoveSpeed * 100 * deltatime;

            if(onGround)
            {
                Velocity.Y = 0;
                if (Input.Space && !Input.LastSpace) Velocity.Y += 10f;
            } else
            {
                Velocity.Y -= 10f * deltatime; // Gravity
            }

            WorldNode.SetPosition2D(WorldNode.Position2D + Velocity * deltatime);

            //Animate.UpdateAnimation(body);

            Input.LastSpace = Input.Space;
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
