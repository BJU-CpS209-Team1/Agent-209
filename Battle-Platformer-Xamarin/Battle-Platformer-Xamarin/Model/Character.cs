using System.Text.RegularExpressions;
using Urho;

namespace Royale_Platformer.Model
{
    public abstract class Character : ISerializer
    {
        public CharacterClass Class { get; protected set; }
        public Weapon HeldWeapon { get; protected set; }
        public bool Armor { get; set; }
        public int MaxHealth { get; protected set; }
        public int Health { get; protected set; }
        public int Score { get; protected set; }

        public Node CharacterNode { get; set; }
        public float MoveSpeed { get; set; }
        public Vector2 Velocity;

        public Character(CharacterClass characterClass, int maxHealth)
        {
            Class = characterClass;
            // TODO: Set HeldWeapon
            Armor = false;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Score = 0;

            Velocity = new Vector2();
        }

        public abstract void Update(float deltatime);

        public abstract void Hit(Bullet bullet);
        public abstract ISerializer Deserialize(string serialized);

        public string Serialize()
        {
            string output = "";
            output += CharacterNode.Position.X.ToString() + ",";
            output += CharacterNode.Position.Y.ToString() + ",";
            output += CharacterNode.Position.Z.ToString();
            return output;
        }

    }
}
