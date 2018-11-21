using Battle_Platformer_Xamarin.Model;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class CharacterEnemy : Character
    {
        private float direction = 1f;

        public CharacterEnemy(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            MoveSpeed = 10;
        }

        public override void Update(float deltatime)
        {
            bool onLeft  = Collision.LeftMiddle  || Collision.TopLeft;
            bool onRight = Collision.RightMiddle || Collision.TopRight;

            if (onLeft)  direction = 1f;
            if (onRight) direction = -1f;

            if (deltatime > 0.05f) deltatime = 0f;
            float speed = MoveSpeed * direction * deltatime * deltatime * 80f;
            WorldNode.SetPosition2D(WorldNode.Position2D + new Vector2(speed, 0));
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
