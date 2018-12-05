// --------------------
// Character.cs
// Elias Watson, Isaac Abrahamson
// Character abstract class
// --------------------

using Battle_Platformer_Xamarin.Model;
using System;
using System.Text.RegularExpressions;
using System.Timers;
using Urho;
using Urho.Resources;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    // Character abstract class
    // Provides a parent for enemy and player character classes
    public abstract class Character : WorldObject
    {
        // The character's class (gunner, support, tank)
        public CharacterClass Class { get; set; }

        // The character's currently held weapon
        public Weapon HeldWeapon { get; set; }

        // Does the character have armor
        public bool Armor { get; set; }

        // The amount of health the character will start with
        public int MaxHealth { get; set; }

        // The character's current health
        public int Health { get; set; }

        // The character's score
        public int Score { get; set; }

        // Timer for controling the weapon cooldown time
        public Timer CooldownTimer { get; set; }

        // The number of 0.1 seconds left of the current weapon cooldown
        public int Cooldown { get; set; }

        // The character's movement speed
        public float MoveSpeed { get; set; }

        // The character's velocity
        public Vector2 Velocity;

        // The character's position in the world
        public Vector3 Position { get; set; }

        // The character's sprite
        public StaticSprite2D CharacterStaticSprite { get; set; }

        // Is the character's shield up
        public bool ShieldUp { get; set; }

        // The character's shield's Urho node
        public Node ShieldNode { get; set; }

        // The character's attack sprite
        public Sprite2D PlayerSpriteAttack { get; set; }

        public Sprite2D PlayerImage1 { get; set; }
        public Sprite2D PlayerImage2 { get; set; }

        // The character's jump sprite
        public Sprite2D PlayerSpriteJump { get; set; }

        // Creates a new character
        // <characterClass> is the character's class (gunner, support, tank)
        // <maxHealth> is the character's starting health
        public Character(CharacterClass characterClass, int maxHealth)
        {
            if (maxHealth < 0)
                throw new Exception("Invalid character max health!");

            Class = characterClass;
            HeldWeapon = new WeaponKnife();
            Armor = false;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Score = 0;

            Cooldown = 0;
            CooldownTimer = new Timer();
            CooldownTimer.Elapsed += new ElapsedEventHandler(RunCooldown);
            CooldownTimer.Interval = 100;
            CooldownTimer.Enabled = false;

            Velocity = new Vector2();

            switch (Class)
            {
                case CharacterClass.Gunner:
                    PlayerImage1 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png2/attack1/2_Special_forces_attack_Attack1_005.png");
                    PlayerImage2 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png2/attack/2_Special_forces_attack_Attack_000_center.png");
                    PlayerSpriteJump = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png2/jump/2_Special_forces_Jump_003.png");
                    break;
                case CharacterClass.Support:
                    PlayerImage1 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png1/attack1/1_Special_forces_attack_Attack1_005.png");
                    PlayerImage2 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png1/attack/1_Special_forces_attack_Attack_000_center.png");
                    PlayerSpriteJump = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png1/jump/1_Special_forces_Jump_003.png");
                    break;
                case CharacterClass.Tank:
                    PlayerImage1 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png3/attack1/3_Special_forces_Attack1_003.png");
                    PlayerImage2 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png3/attack/3_Special_forces_Attack_002_center.png");
                    PlayerSpriteJump = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png3/jump/3_Special_forces_Jump_003.png");
                    break;
            }
            PlayerSpriteAttack = PlayerImage1;
        }

        // Creates a new character
        // <characterClass> is the character's class (gunner, support, tank)
        // <maxHealth> is the character's starting health
        // <position> is the character's starting position
        public Character(CharacterClass characterClass, int maxHealth, Vector3 position)
        {
            if (maxHealth < 0)
                throw new Exception("Invalid character max health!");

            Class = characterClass;
            HeldWeapon = new WeaponKnife();
            Armor = false;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Score = 0;

            Cooldown = 0;
            CooldownTimer = new Timer();
            CooldownTimer.Elapsed += new ElapsedEventHandler(RunCooldown);
            CooldownTimer.Interval = 100;
            CooldownTimer.Enabled = false;

            Velocity = new Vector2();
            Position = position;

            switch (Class)
            {
                case CharacterClass.Gunner:
                    PlayerImage1 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png2/attack1/2_Special_forces_attack_Attack1_005.png");
                    PlayerImage2 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png2/attack/2_Special_forces_attack_Attack_000_center.png");
                    PlayerSpriteJump = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png2/jump/2_Special_forces_Jump_003.png");
                    break;
                case CharacterClass.Support:
                    PlayerImage1 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png1/attack1/1_Special_forces_attack_Attack1_005.png");
                    PlayerImage2 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png1/attack/1_Special_forces_attack_Attack_000_center.png");
                    PlayerSpriteJump = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png1/jump/1_Special_forces_Jump_003.png");
                    break;
                case CharacterClass.Tank:
                    PlayerImage1 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png3/attack1/3_Special_forces_Attack1_003.png");
                    PlayerImage2 = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png3/attack/3_Special_forces_Attack_002_center.png");
                    PlayerSpriteJump = GameApp.Instance.ResourceCache.GetSprite2D("characters/special_forces/png3/jump/3_Special_forces_Jump_003.png");
                    break;
            }
            PlayerSpriteAttack = PlayerImage1;
        }

        // Creates the character's Urho node
        // <scene> is the Urho scene
        // <sprite> is the character's sprite
        // <shieldSprite> is the character's shield's sprite
        // <pos> is the starting position of the character
        public virtual void CreateNode(Scene scene, Sprite2D sprite, Sprite2D shieldSprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.Position = new Vector3(pos);
            Position = WorldNode.Position;
            WorldNode.SetScale(1f / 12.14f);

            CharacterStaticSprite = WorldNode.CreateComponent<StaticSprite2D>();
            CharacterStaticSprite.BlendMode = BlendMode.Alpha;
            CharacterStaticSprite.Sprite = sprite;

            ShieldNode = scene.CreateChild();
            ShieldNode.Position = new Vector3(WorldNode.Position);

            StaticSprite2D staticSprite = ShieldNode.CreateComponent<StaticSprite2D>();
            staticSprite.BlendMode = BlendMode.Alpha;
            staticSprite.Sprite = shieldSprite;

            WorldHitbox = new Hitbox();
            WorldHitbox.Size = new Vector2(0.5f, 1f);
        }

        // Called when the character is hit by a bullet
        // <bullet> is the bullet that struck the character
        public virtual void Hit(Bullet bullet)
        {
            if (ShieldUp) return;

            if (Armor)
            {
                Armor = false;
                return;
            }

            Health -= bullet.Damage;
        }

        // Upgrade the character's weapon
        public virtual bool UpgradeWeapon()
        {
            if (!HeldWeapon.Upgradeable) return false;

            // Upgrade weapon
            HeldWeapon = HeldWeapon.Upgrade(Class);

            // Increase score  
            if (GameApp.Instance.hardcore)
                Score += 30;
            else
                Score += 20;

            // Update image
            UpdateImage();

            Cooldown = -1;
            CooldownTimer.Enabled = false;

            return true;
        }

        public void UpdateImage()
        {
            PlayerSpriteAttack = PlayerImage2;
        }

        // Abstract method for updating the character every frame
        // <deltatime> time in seconds since the last frame
        public abstract void Update(float deltatime);

        // Timer method for weapon cooldown
        private void RunCooldown(object sender, ElapsedEventArgs e)
        {
            --Cooldown;

            if (Cooldown < 1)
                CooldownTimer.Enabled = false;
        }

        //public abstract ISerializer Deserialize(string serialized);

        public string Serialize()
        {
            Position = WorldNode.Position;
            return $"{Class},{HeldWeapon},{Armor},{Health},{MaxHealth},{Score},{Position.X.ToString()},{Position.Y.ToString()},{Position.Z.ToString()}";
        }

    }
}
