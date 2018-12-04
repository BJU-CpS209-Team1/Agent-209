using Battle_Platformer_Xamarin.Model;
using System;
using System.Text.RegularExpressions;
using System.Timers;
using Urho;
using Urho.Resources;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public abstract class Character : WorldObject
    {
        public CharacterClass Class { get; set; }
        public Weapon HeldWeapon { get; set; }
        public bool Armor { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }

        public Timer CooldownTimer { get; set; }
        public int Cooldown { get; set; }

        public float MoveSpeed { get; set; }
        public Vector2 Velocity;

        public Vector3 Position { get; set; }

        public StaticSprite2D PlayerStaticSprite { get; set; }

        public bool ShieldUp { get; set; }
        public Node ShieldNode { get; set; }

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
        }

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
        }

        public virtual void CreateNode(Scene scene, Sprite2D sprite, Sprite2D shieldSprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.Position = new Vector3(pos);
            Position = WorldNode.Position;
            WorldNode.SetScale(1f / 12.14f);

            PlayerStaticSprite = WorldNode.CreateComponent<StaticSprite2D>();
            PlayerStaticSprite.BlendMode = BlendMode.Alpha;
            PlayerStaticSprite.Sprite = sprite;

            ShieldNode = scene.CreateChild();
            ShieldNode.Position = new Vector3(WorldNode.Position);

            StaticSprite2D staticSprite = ShieldNode.CreateComponent<StaticSprite2D>();
            staticSprite.BlendMode = BlendMode.Alpha;
            staticSprite.Sprite = shieldSprite;

            WorldHitbox = new Hitbox();
            WorldHitbox.Size = new Vector2(0.5f, 1f);
        }

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

        public virtual bool UpgradeWeapon()
        {
            if (!HeldWeapon.Upgradeable) return false;

            HeldWeapon = HeldWeapon.Upgrade(Class);
            if (!GameApp.Instance.schaubMode)
                GameApp.Instance.PlayerSpriteAttack = GameApp.Instance.PlayerImage2;
            
            if (GameApp.Instance.hardcore)
                    GameApp.Instance.PlayerCharacter.Score += 30;
            else
                GameApp.Instance.PlayerCharacter.Score += 20;

            return true;
        }

        public abstract void Update(float deltatime);

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
