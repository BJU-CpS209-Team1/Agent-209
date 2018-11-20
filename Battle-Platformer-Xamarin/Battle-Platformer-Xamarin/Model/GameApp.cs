using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Urho;
using Urho.Urho2D;
using System.Timers;
using System.Globalization;
using Battle_Platformer_Xamarin.Model;
using Urho.Audio;

namespace Royale_Platformer.Model
{
    public class GameApp : Application
    {
        public CharacterPlayer PlayerCharacter { get; private set; }
        public List<Character> Characters { get; private set; }

        public List<Pickup> Pickups { get; set; }
        public List<Bullet> Bullets { get; set; }

        public List<MapTile> Tiles { get; set; }

        private List<WorldObject> collisionObjects;

        public bool LoadGame { get; set; }

        private Scene scene;
        private Node cameraNode;

        public GameApp(ApplicationOptions options) : base(options)
        {
            Characters = new List<Character>();
            Pickups = new List<Pickup>();
            Bullets = new List<Bullet>();
            Tiles = new List<MapTile>();
            collisionObjects = new List<WorldObject>();
            LoadGame = false;
        }

        protected override void Start()
        {
            base.Start();

            float halfWidth = Graphics.Width * 0.5f * PixelSize;
            float halfHeight = Graphics.Height * 0.5f * PixelSize;

            // Create Scene
            scene = new Scene();
            scene.CreateComponent<Octree>();
            //scene.CreateComponent<PhysicsWorld2D>();

            cameraNode = scene.CreateChild("Camera");
            cameraNode.Position = new Vector3(0, 0, -10);

            Camera camera = cameraNode.CreateComponent<Camera>();
            camera.Orthographic = true;
            camera.OrthoSize = 2 * halfHeight;
            camera.Zoom = Math.Min(Graphics.Width / 1920.0f, Graphics.Height / 1080.0f);

            CreatePlayer(0, 0, 0);
            CreateMap();
            PlayMusic();

            // Setup Viewport
            Renderer.SetViewport(0, new Viewport(Context, scene, camera, null));
        }

        private void PlayMusic()
        {
            var music = ResourceCache.GetSound("sounds/loop1.ogg");
            music.Looped = true;
            Node musicNode = new Scene().CreateChild("Music");
            SoundSource musicSource = musicNode.CreateComponent<SoundSource>();
            musicSource.SetSoundType(SoundType.Music.ToString());
            musicSource.Play(music);
        }

        private void CreatePlayer(float x, float y, float z)
        {
            var playerSprite = ResourceCache.GetSprite2D("characters/special forces/png1/attack/1_Special_forces_attack_Attack_000.png");

            Node playerNode = scene.CreateChild("StaticSprite2D");
            playerNode.Position = new Vector3(x, y, z);
            playerNode.SetScale(1f / 12.14f);

            //AnimatedSprite2D playerAnimatedSprite = playerNode.CreateComponent<AnimatedSprite2D>();
            //playerAnimatedSprite.BlendMode = BlendMode.Alpha;
            //playerAnimatedSprite.Sprite = playerSprite;

            StaticSprite2D playerStaticSprite = playerNode.CreateComponent<StaticSprite2D>();
            playerStaticSprite.BlendMode = BlendMode.Alpha;
            playerStaticSprite.Sprite = playerSprite;

            /*
            RigidBody2D playerBody = playerNode.CreateComponent<RigidBody2D>();
            playerBody.BodyType = BodyType2D.Dynamic;
            playerBody.GravityScale = 5f;
            playerBody.FixedRotation = true;

            CollisionBox2D playerShape = playerNode.CreateComponent<CollisionBox2D>();
            playerShape.Size = new Vector2(1f, 5f);
            playerShape.Friction = 0.5f;
            playerShape.Density = 1.0f;
            */

            CharacterPlayer player = new CharacterPlayer(CharacterClass.Gunner, 10);
            player.WorldNode = playerNode;

            AddPlayer(player);

            // save player for testing
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 10000;
            timer.Enabled = true;
        }

        private void CreateMap()
        {
            /*
            TmxFile2D mapFile = ResourceCache.GetTmxFile2D("map/levels/starter.tmx");
            if (mapFile == null)
                throw new Exception("Map not found");
                */

            //Node mapNode = scene.CreateChild("TileMap");
            //TileMap2D tileMap = mapNode.CreateComponent<TileMap2D>();
            //tileMap.TmxFile = mapFile;

            Sprite2D groundSprite = ResourceCache.GetSprite2D("map/levels/platformer-art-complete-pack-0/Base pack/Tiles/grassMid.png");
            if (groundSprite == null)
                throw new Exception("Texture not found");

            for(int i = 0; i < 10; ++i)
            {
                MapTile tile = new MapTile(scene, groundSprite, new Vector2(i - 5, -3));
                Tiles.Add(tile);
                collisionObjects.Add(tile);
            }

            for(int i = 0; i < 4; ++i)
            {
                MapTile tile = new MapTile(scene, groundSprite, new Vector2(i - 5, -1));
                Tiles.Add(tile);
                collisionObjects.Add(tile);
            }

            CreatePickups();
        }

        private void CreatePickups()
        {
            var weaponSprite = ResourceCache.GetSprite2D("map/levels/platformer-art-complete-pack-0/Request pack/Tiles/raygunBig.png");
            var armorSprite = ResourceCache.GetSprite2D("map/levels/platformer-art-complete-pack-0/Request pack/Tiles/shieldGold.png");

            if (weaponSprite == null || armorSprite == null)
                throw new Exception("Texture not found");

            for (int i = 0; i < 4; ++i)
            {
                Pickups.Add(new PickupWeaponUpgrade(scene, weaponSprite, new Vector2(i - 5, 0)));
            }

            for (int i = 0; i < 2; ++i)
            {
                Pickups.Add(new PickupArmor(scene, armorSprite, new Vector2(i - 5, -2)));
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Save("latest.txt");
        }

        protected override void OnUpdate(float timeStep)
        {
            base.OnUpdate(timeStep);

            foreach (Character c in Characters)
            {
                foreach (Pickup p in Pickups.ToList())
                {
                    if(c.Collides(p))
                    {
                        if (p.PickUp(c))
                        {
                            p.WorldNode.Remove();
                            Pickups.Remove(p);
                        }
                    }
                }
            }

            PlayerCharacter.UpdateCollision(collisionObjects);

            PlayerCharacter.Input.W = Input.GetKeyDown(Key.W);
            PlayerCharacter.Input.A = Input.GetKeyDown(Key.A);
            PlayerCharacter.Input.S = Input.GetKeyDown(Key.S);
            PlayerCharacter.Input.D = Input.GetKeyDown(Key.D);
            PlayerCharacter.Input.Space = Input.GetKeyDown(Key.Space);
            PlayerCharacter.Update(timeStep);
        }

        public void AddPlayer(CharacterPlayer character)
        {
            PlayerCharacter = character;
            AddCharacter(character);
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public string Serialize()
        {
            string output = "";

            string characterString = "";
            foreach (var character in Characters)
            {
                characterString += character.Serialize();
            }
            output += characterString;

            return output;
        }

        public void Deserialize(string serialized)
        {
            // deserialize position of player
            string[] charactersSplit = serialized.Split(',');
            float x = float.Parse(charactersSplit[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(charactersSplit[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(charactersSplit[2], CultureInfo.InvariantCulture.NumberFormat);

            PlayerCharacter.WorldNode.Position = new Vector3(x, y, z);
        }

        public void Load(string fileName)
        {
            string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            if (File.Exists(PATH))
            {
                string data = File.ReadLines(PATH).First();
                Deserialize(data);
            }
            else
            {
                throw new Exception("The call could not be completed as dialed. Please check check the number, and try your call again.");
            }
        }

        public void Save(string fileName)
        {
            string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            
            string serialized = Serialize();
            File.WriteAllText(PATH, serialized);
        }
    }
}
