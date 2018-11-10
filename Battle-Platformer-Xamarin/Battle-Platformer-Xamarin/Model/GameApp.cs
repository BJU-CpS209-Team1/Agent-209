using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Urho;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    class GameApp : Application, ISerializer
    {
        public CharacterPlayer PlayerCharacter { get; private set; }
        public List<Character> Characters { get; private set; }

        public List<Pickup> Pickups { get; set; }
        public List<Bullet> Bullets { get; set; }

        private Scene scene;
        private Node cameraNode;

        public GameApp(ApplicationOptions options) : base(options)
        {
            Characters = new List<Character>();
            Pickups = new List<Pickup>();
            Bullets = new List<Bullet>();
        }

        protected override void Start()
        {
            base.Start();

            float halfWidth = Graphics.Width * 0.5f * PixelSize;
            float halfHeight = Graphics.Height * 0.5f * PixelSize;

            // Create Scene
            scene = new Scene();
            scene.CreateComponent<Octree>();
            scene.CreateComponent<PhysicsWorld2D>();

            cameraNode = scene.CreateChild("Camera");
            cameraNode.Position = new Vector3(0, 0, -10);

            Camera camera = cameraNode.CreateComponent<Camera>();
            camera.Orthographic = true;
            camera.OrthoSize = 2 * halfHeight;
            camera.Zoom = 0.1f * Math.Min(Graphics.Width / 1920.0f, Graphics.Height / 1080.0f);

            CreatePlayer();

            // TEMP: Create Ground
            Sprite2D groundSprite = ResourceCache.GetSprite2D("map/assets/platformer-art-complete-pack-0/Base pack/Tiles/grassMid.png");
            if (groundSprite == null)
                throw new Exception("Texture not found");

            Node groundNode = scene.CreateChild("Ground");
            groundNode.Position = new Vector3(0, -10, 0);
            groundNode.CreateComponent<RigidBody2D>();
            groundNode.Scale = new Vector3(100f, 10f, 1f);

            StaticSprite2D groundStaticSprite = groundNode.CreateComponent<StaticSprite2D>();
            groundStaticSprite.Sprite = groundSprite;

            CollisionBox2D groundShape = groundNode.CreateComponent<CollisionBox2D>();
            groundShape.Size = new Vector2(0.75f, 1f);
            groundShape.Friction = 0.5f;

            // Setup Viewport
            Renderer.SetViewport(0, new Viewport(Context, scene, camera, null));

            Renderer.DrawDebugGeometry(false);
            var debugRender = scene.GetOrCreateComponent<DebugRenderer>();
            var physicsComp = scene.GetComponent<PhysicsWorld2D>();
            physicsComp.DrawDebugGeometry(debugRender, false);
            groundShape.DrawDebugGeometry(debugRender, false);
        }

        private void CreatePlayer()
        {
            Sprite2D playerSprite = ResourceCache.GetSprite2D("characters/special forces/png2/idle/2_Special_forces_Idle_000.png");

            Node playerNode = scene.CreateChild("StaticSprite2D");
            playerNode.Position = new Vector3(0, 0, 0);

            StaticSprite2D playerStaticSprite = playerNode.CreateComponent<StaticSprite2D>();
            playerStaticSprite.BlendMode = BlendMode.Alpha;
            playerStaticSprite.Sprite = playerSprite;

            RigidBody2D playerBody = playerNode.CreateComponent<RigidBody2D>();
            playerBody.BodyType = BodyType2D.Dynamic;
            playerBody.GravityScale = 5f;
            playerBody.FixedRotation = true;

            CollisionBox2D playerShape = playerNode.CreateComponent<CollisionBox2D>();
            playerShape.Size = new Vector2(1f, 5f);
            playerShape.Friction = 0.5f;
            playerShape.Density = 1.0f;

            CharacterPlayer player = new CharacterPlayer(CharacterClass.Gunner, 10);
            player.CharacterNode = playerNode;

            AddPlayer(player);
        }

        protected override void OnUpdate(float timeStep)
        {
            base.OnUpdate(timeStep);

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
            // dummy data to test
            return "PlayerCharacter=CharacterPlayer.Scout;Characters=Character1,Character2,Character3;Pickups=Pickup1,Pickup2;Bullets=Bullet1,Bullet2";
        }

        public ISerializer Deserialize(string serialized)
        {
            return new GameApp(null);
        }

        public GameApp Load(string fileName)
        {
            string path = $"./.data/{fileName}";

            if (File.Exists(path))
            {
                string data = File.ReadLines(path).First();
                return (GameApp) Deserialize(data);
            }
            else
            {
                throw new Exception("The call could not be completed as dialed. Please check check the number, and try your call again.");
            }
        }

        public void Save(string fileName)
        {
            // create .data folder and make it private
            const string PATH = "./.data/";
            if (!Directory.Exists(PATH))
            {
                DirectoryInfo pathInfo = Directory.CreateDirectory(PATH);
                pathInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            // Write data to file
            string serialized = Serialize();
            File.WriteAllText(PATH + fileName, serialized);
        }
    }
}
