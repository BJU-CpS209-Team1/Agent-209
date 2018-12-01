using Battle_Platformer_Xamarin.Model;
using System;
using System.Globalization;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public class CharacterEnemy : Character
    {
        private static Random random = new Random();

        private float direction = 1f;
        private float shieldCooldown = 0;

        private float jumpChance = 0.001f;
        private float fireChance = 0.01f;

        public CharacterEnemy(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
            MoveSpeed = 2;
        }

        public CharacterEnemy(CharacterClass characterClass, int maxHealth, Vector3 position) : base(characterClass, maxHealth, position)
        {
            MoveSpeed = 2;
        }

        public override void Update(float deltatime)
        {
            bool onBottom = Collision.BottomLeft || Collision.BottomMiddle || Collision.BottomRight;
            bool onTop = Collision.TopLeft || Collision.TopMiddle || Collision.TopRight;
            bool onLeft = Collision.LeftMiddle || Collision.TopLeft;
            bool onRight = Collision.RightMiddle || Collision.TopRight;

            if (deltatime > 0.05f) deltatime = 0f;

            if (Class == CharacterClass.Tank)
            {
                shieldCooldown -= deltatime;
                if (shieldCooldown <= 0f)
                {
                    shieldUp = !shieldUp;
                    shieldCooldown = (float) random.NextDouble() * 10;
                }
            }

            if (onLeft) direction = 1f;
            if (onRight) direction = -1f;
            Velocity.X = MoveSpeed * direction;

            if (onBottom)
                Velocity.Y = (random.NextDouble() < jumpChance) ? 10f : 0f;
            else
                Velocity.Y -= 10f * deltatime; // Gravity

            if (onTop && Velocity.Y > 0) Velocity.Y = 0;

            if ((random.NextDouble() < fireChance) && !shieldUp) // Can't shoot if shield is up
            {
                // run timer to count down
                if (Cooldown <= 0)
                {
                    Cooldown = HeldWeapon.Cooldown;
                    CooldownTimer.Enabled = true;

                    if (GameApp.Instance.PlayerCharacter.WorldNode.IsDeleted)
                        return;

                    Vector2 dir = GameApp.Instance.PlayerCharacter.WorldNode.Position2D - WorldNode.Position2D;
                    dir.Normalize();
                    GameApp.Instance.CreateBullets(HeldWeapon.Fire(dir), this);
                }
            }

            WorldNode.SetPosition2D(WorldNode.Position2D + Velocity * deltatime);
        }

        public Vector3 Deserialize(string serialized)
        {
            string[] coords = serialized.Split(',');

            float x = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(coords[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector3(x, y, z);
        }

        public string GetSprite()
        {
            switch (Class)
            {
                case CharacterClass.Gunner:
                    return "characters/special_forces/png2/attack/2_Special_forces_attack_Attack_000_center.png";
                case CharacterClass.Support:
                    return "characters/special_forces/png1/attack/1_Special_forces_attack_Attack_000_center.png";
                case CharacterClass.Tank:
                    return "characters/special_forces/png3/attack/3_Special_forces_Attack_000_center.png";
            }
            return "";
        }
    }
}
