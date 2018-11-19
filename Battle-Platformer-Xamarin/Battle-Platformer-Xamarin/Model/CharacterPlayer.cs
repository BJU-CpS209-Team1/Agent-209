using Urho;
using Urho.Urho2D;

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
            Velocity.X = 0;
            if (Input.A) Velocity.X -= MoveSpeed * 100 * deltatime;
            if (Input.D) Velocity.X += MoveSpeed * 100 * deltatime;
            if (Input.Space && !Input.LastSpace) Velocity.Y += 25f;

            /*
            var body = CharacterNode.GetComponent<RigidBody2D>();
            body.SetLinearVelocity(new Urho.Vector2(Velocity.X, body.LinearVelocity.Y + Velocity.Y));
            */

            // Gravity
            Velocity.Y -= 10f * deltatime;

            WorldNode.SetPosition2D(WorldNode.Position2D + Velocity * deltatime);

            if(WorldNode.Position2D.Y < -2)
            {
                Vector2 v = WorldNode.Position2D;
                v.Y = -2;
                WorldNode.SetPosition2D(v);
            }

            Input.LastSpace = Input.Space;
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
