using Battle_Platformer_Xamarin.Model;
using System;
using System.Text.RegularExpressions;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    public abstract class Character : WorldObject
    {
        public CharacterClass Class { get; protected set; }
        public Weapon HeldWeapon { get; set; }
        public bool Armor { get; set; }
        public int MaxHealth { get; protected set; }
        public int Health { get; set; }
        public int Score { get; protected set; }

        public float MoveSpeed { get; set; }
        public Vector2 Velocity;

        public Vector3 Position { get; set; }

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

            Velocity = new Vector2();
            
            Position = position;
        }


        public virtual void CreateNode(Scene scene, Sprite2D sprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.Position = new Vector3(pos);
            Position = WorldNode.Position;
            WorldNode.SetScale(1f / 12.14f);

            StaticSprite2D playerStaticSprite = WorldNode.CreateComponent<StaticSprite2D>();
            playerStaticSprite.BlendMode = BlendMode.Alpha;
            playerStaticSprite.Sprite = sprite;
        }

        public virtual void Hit(Bullet bullet)
        {
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
            return true;
        }

        public abstract void Update(float deltatime);

        //public abstract ISerializer Deserialize(string serialized);

        public string Serialize()
        {
            Position = WorldNode.Position;
            return $"{Position.X.ToString()},{Position.Y.ToString()},{Position.Z.ToString()}";
        }

    }
}
