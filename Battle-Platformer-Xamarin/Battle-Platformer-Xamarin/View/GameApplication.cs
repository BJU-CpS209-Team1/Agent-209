using System;
using System.Collections.Generic;
using System.Text;
using Urho;

namespace Battle_Platformer_Xamarin.View
{
    class GameApplication : Application
    {
        private Scene scene;
        private Node cameraNode;

        public GameApplication(ApplicationOptions options) : base(options)
        {
        }

        protected override void Start()
        {
            base.Start();

            // Create Scene
            scene = new Scene();
            scene.CreateComponent<Octree>();

            cameraNode = scene.CreateChild("Camera");
            cameraNode.Position = new Vector3(0, 0, -10);

            Camera camera = cameraNode.CreateComponent<Camera>();
            camera.Orthographic = true;

            // Setup Viewport
            Renderer.SetViewport(0, new Viewport(Context, scene, camera, null));
        }
    }
}
