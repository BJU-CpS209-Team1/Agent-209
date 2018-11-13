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
            Velocity.Y = 0;
            if (Input.A) Velocity.X -= MoveSpeed * 1000 * deltatime;
            if (Input.D) Velocity.X += MoveSpeed * 1000 * deltatime;
            if (Input.Space && !Input.LastSpace) Velocity.Y += 75;

            var body = CharacterNode.GetComponent<RigidBody2D>();
            body.SetLinearVelocity(new Urho.Vector2(Velocity.X, body.LinearVelocity.Y + Velocity.Y));

            Input.LastSpace = Input.Space;
        }

        public override void Hit(Bullet bullet)
        {
            if(Armor)
            {
                Armor = false;
                return;
            }

            Health -= bullet.Damage;
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
