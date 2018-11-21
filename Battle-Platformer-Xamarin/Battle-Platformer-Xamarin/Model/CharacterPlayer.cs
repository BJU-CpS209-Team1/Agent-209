using Urho;
using Urho.Urho2D;
using Battle_Platformer_Xamarin.Model;
using System.Globalization;

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
            bool onBottom = Collision.BottomLeft  || Collision.BottomMiddle || Collision.BottomRight;
            bool onTop    = Collision.TopLeft     || Collision.TopMiddle    || Collision.TopRight;
            bool onLeft   = Collision.LeftMiddle  || Collision.TopLeft;
            bool onRight  = Collision.RightMiddle || Collision.TopRight;

            Velocity.X = 0;

            if (Input.A) Velocity.X -= MoveSpeed * 100 * deltatime;
            if (Input.D) Velocity.X += MoveSpeed * 100 * deltatime;

            if (onLeft  && Velocity.X < 0) Velocity.X = 0;
            if (onRight && Velocity.X > 0) Velocity.X = 0;

            if(onBottom)
            {
                Velocity.Y = 0;
                if (Input.Space && !Input.LastSpace) Velocity.Y += 10f;
            } else
            {
                Velocity.Y -= 10f * deltatime; // Gravity
            }

            if (onTop && Velocity.Y > 0) Velocity.Y = 0;

            WorldNode.SetPosition2D(WorldNode.Position2D + Velocity * deltatime);

            //Animate.UpdateAnimation(body);

            Input.LastSpace = Input.Space;
        }

        public Vector3 Deserialize(string serialized)
        {
            string[] charactersSplit = serialized.Split(',');
            float x = float.Parse(charactersSplit[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(charactersSplit[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(charactersSplit[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector3(x, y, z);
        }
    }
}
