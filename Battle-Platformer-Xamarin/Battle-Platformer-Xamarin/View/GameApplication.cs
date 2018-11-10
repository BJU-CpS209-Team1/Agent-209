using System;
using System.Collections.Generic;
using System.Text;
using Urho;
using Urho.Urho2D;

namespace Battle_Platformer_Xamarin.View
{
    class GameApplication : Application
    {
        private static Random r = new Random();

        private Scene scene;
        private Node cameraNode;

        public GameApplication(ApplicationOptions options) : base(options)
        {
        }

        protected override void Start()
        {
            base.Start();

            float halfWidth = Graphics.Width * 0.5f * PixelSize;
            float halfHeight = Graphics.Height * 0.5f * PixelSize;

            // Create Scene
            scene = new Scene();
            scene.CreateComponent<Octree>();

            cameraNode = scene.CreateChild("Camera");
            cameraNode.Position = new Vector3(0, 0, -10);

            Camera camera = cameraNode.CreateComponent<Camera>();
            camera.Orthographic = true;

            Sprite2D coinSprite = ResourceCache.GetSprite2D("map/assets/platformer-art-complete-pack-0/Base pack/Items/coinSilver.png");
            if (coinSprite == null)
                throw new Exception("Unable to load resource");

            for(int i = 0; i < 100; ++i)
            {
                Node spriteNode = scene.CreateChild("StaticSprite2D");
                spriteNode.Position = RndV3(-halfWidth, halfWidth, -halfHeight, halfHeight);

                StaticSprite2D staticSprite = spriteNode.CreateComponent<StaticSprite2D>();
                staticSprite.Color = new Color(Rnd(0, 1), Rnd(0, 1), Rnd(0, 1), 1);
                staticSprite.BlendMode = BlendMode.Alpha;
                staticSprite.Sprite = coinSprite;
            }

            // Setup Viewport
            Renderer.SetViewport(0, new Viewport(Context, scene, camera, null));
        }

        private static Vector3 RndV3(float min1, float max1, float min2, float max2)
        {
            return new Vector3(Rnd(min1, max1), Rnd(min2, max2), 0f);
        }

        private static float Rnd(float min, float max)
        {
            return (float)r.NextDouble() * (max - min) + min;
        }
    }
}
