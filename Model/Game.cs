using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royale_Platformer.Model
{
    class Game
    {
        public CharacterPlayer PlayerCharacter { get; private set; }
        public List<Character> Characters { get; private set; }

        public List<Pickup> Pickups { get; set; }
        public List<Bullet> Bullets { get; set; }

        public Game()
        {

        }

        public void Update()
        {

        }

        public void CreatePlayer(CharacterPlayer character)
        {

        }

        public void AddCharacter(Character character)
        {

        }
    }
}
