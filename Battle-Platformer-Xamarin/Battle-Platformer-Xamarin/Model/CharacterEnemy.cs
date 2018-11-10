namespace Royale_Platformer.Model
{
    class CharacterEnemy : Character
    {
        public CharacterEnemy(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
        }

        public override void Hit(Bullet bullet)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(float deltatime)
        {
            throw new System.NotImplementedException();
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
