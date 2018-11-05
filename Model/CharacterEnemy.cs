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
    }
}
