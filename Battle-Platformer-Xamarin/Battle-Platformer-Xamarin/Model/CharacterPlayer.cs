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
            public bool Space;
            public bool LeftClick;
            public Vector2 MousePosition;
        }

        public PlayerInput Input;

        public CharacterPlayer(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            Input = new PlayerInput();
            MoveSpeed = 5;
        }

        public override void Update(float deltatime)
        {
            bool onBottom = Collision.BottomLeft  || Collision.BottomMiddle || Collision.BottomRight;
            bool onTop    = Collision.TopLeft     || Collision.TopMiddle    || Collision.TopRight;
            bool onLeft   = Collision.LeftMiddle  || Collision.TopLeft;
            bool onRight  = Collision.RightMiddle || Collision.TopRight;

            Velocity.X = 0;

            if (Input.A) Velocity.X -= MoveSpeed;
            if (Input.D) Velocity.X += MoveSpeed;

            if (onLeft  && Velocity.X < 0) Velocity.X = 0;
            if (onRight && Velocity.X > 0) Velocity.X = 0;

            if(onBottom)
            {
                Velocity.Y = 0;
                if (Input.Space) Velocity.Y += 10f;
            } else
            {
                Velocity.Y -= 10f * deltatime; // Gravity
            }

            if (onTop && Velocity.Y > 0) Velocity.Y = 0;

            WorldNode.SetPosition2D(WorldNode.Position2D + Velocity * deltatime);

            //Animate.UpdateAnimation(body);

            if(Input.LeftClick)
            {
                Vector2 dir = Input.MousePosition;
                dir.Normalize();
                GameApp.Instance.CreateBullets(HeldWeapon.Fire(dir), this);
            }
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
