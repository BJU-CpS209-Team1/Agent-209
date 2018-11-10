namespace Royale_Platformer.Model
{
    class CharacterPlayer : Character
    {
        public struct PlayerInput
        {
            public bool W, A, S, D;
            public bool Space;
        }

        public PlayerInput Input;

        public CharacterPlayer(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            Input = new PlayerInput();
            Velocity = new Urho.Vector3();
            MoveSpeed = 1;
        }

        public override void Update(float deltatime)
        {
            if (Input.A) Velocity.X -= MoveSpeed;
            if (Input.D) Velocity.X += MoveSpeed;

            CharacterNode.Position += Velocity * deltatime;
            Velocity -= Velocity * deltatime; // Air resistance
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
