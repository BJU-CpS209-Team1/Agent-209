namespace Royale_Platformer.Model
{
    class CharacterPlayer : Character
    {
        public CharacterPlayer(CharacterClass characterClass, int maxHealth) : base(characterClass, maxHealth)
        {
        }

        public override void Hit(Bullet bullet)
        {
            throw new System.NotImplementedException();
        }

        public override ISerializer Deserialize(string serialized)
        {
            throw new System.NotImplementedException();
        }
    }
}
