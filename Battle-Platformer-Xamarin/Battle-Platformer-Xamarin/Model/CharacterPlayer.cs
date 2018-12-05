// --------------------
// CharacterPlayer.cs
// Elias Watson
// CharacterPlayer class
// --------------------

using Urho;
using Urho.Urho2D;
using Battle_Platformer_Xamarin.Model;
using System.Globalization;

namespace Royale_Platformer.Model
{
    // CharacterPlayer class
    // Holds the player character
    public class CharacterPlayer : Character
    {
        // A state of input
        public struct PlayerInput
        {
            public bool W, A, S, D;
            public bool Space;
            public bool LeftClick; // Attack (currently E key)
            public bool F; // Shield
            public Vector2 MousePosition;
        }

        // The current state of input
        public PlayerInput Input;

        // Create a player
        // <characterClass> is the enemy's class
        // <maxHealth> is the enemy's starting health
        public CharacterPlayer(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            Input = new PlayerInput();
            MoveSpeed = 5;
        }

        // Update the player (called every frame)
        // <deltatime> is the time in seconds since the last frame
        public override void Update(float deltatime)
        {
            bool onBottom = (Collision.BottomLeft && !Collision.WallLeft) || Collision.BottomMiddle || (Collision.BottomRight && !Collision.WallRight);
            bool onTop = Collision.TopLeft || Collision.TopMiddle || Collision.TopRight;
            bool onLeft = Collision.LeftMiddle || Collision.TopLeft;
            bool onRight = Collision.RightMiddle || Collision.TopRight;

            ShieldUp = (Class == CharacterClass.Tank) && Input.F;

            Velocity.X = 0;
            if (deltatime > 0.05f) deltatime = 0f;

            if (Input.A)
            {
                Velocity.X -= MoveSpeed;
                if (!GameApp.Instance.schaubMode) CharacterStaticSprite.FlipX = true;
            }
            if (Input.D)
            {
                Velocity.X += MoveSpeed;
                if (!GameApp.Instance.schaubMode) CharacterStaticSprite.FlipX = false;
            }

            if (onLeft && Velocity.X < 0) Velocity.X = 0;
            if (onRight && Velocity.X > 0) Velocity.X = 0;

            if (onBottom)
            {
                Velocity.Y = 0;
                CharacterStaticSprite.Sprite = PlayerSpriteAttack;
                if (Input.Space)
                {
                    Velocity.Y += 10f;
                    if (!GameApp.Instance.schaubMode) CharacterStaticSprite.Sprite = PlayerSpriteJump;
                }
            }
            else
            {
                Velocity.Y -= 10f * deltatime; // Gravity
            }

            if (onTop && Velocity.Y > 0) Velocity.Y = 0;

            WorldNode.SetPosition2D(WorldNode.Position2D + Velocity * deltatime);

            if (Input.LeftClick && !ShieldUp) // Can't shoot if shield is up
            {
                // run timer to count down
                if (Cooldown <= 0)
                {
                    Cooldown = HeldWeapon.Cooldown;
                    CooldownTimer.Enabled = true;

                    Vector2 dir = Input.MousePosition;
                    dir.Normalize();
                    GameApp.Instance.CreateBullets(HeldWeapon.Fire(dir), this);
                }
            }
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
