using Battle_Platformer_Xamarin.Model;
using System.Globalization;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class CharacterEnemy : Character
    {
        private float direction = 1f;

        public CharacterEnemy(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            MoveSpeed = 4;
        }

        public CharacterEnemy(CharacterClass characterClass, int maxHealth, Vector3 position) : base(characterClass, maxHealth, position)
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
            float speed = MoveSpeed * direction * deltatime;
            WorldNode.SetPosition2D(WorldNode.Position2D + new Vector2(speed, 0));
        }

        public Vector3 Deserialize(string serialized)
        {
            string[] coords = serialized.Split(',');

            float x = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(coords[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector3(x, y, z);
        }
    }
}
