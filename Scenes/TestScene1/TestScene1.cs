using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Scenes.TestScene1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ECSTEST.Scenes
{
    public class TestScene1Scene : Scene
    {
        public TestScene1Scene(ContentManager contentManager, SceneManager sceneManager) : base(contentManager, sceneManager)
        {
            this._Name = "Test Scene 1";
        }

        public override void LoadContent()
        {
            base.LoadContent();
            PlayerTest TestGuy = new PlayerTest();
            TestGuy.SetPosition(new Vector2(200, 200));
            //_Content.RootDirectory = @"/Scenes/TestScene1";
            var tgTex = _Content.Load<Texture2D>(@"TestScene1\Art\TestGuy");
            Components.DrawComponent dc = new Components.DrawComponent(tgTex);
            Components.FollowMouseComponent fmc = new Components.FollowMouseComponent();
            Components.CollisionComponent cc = new Components.CollisionComponent();
            TestGuy.AddComponent(cc);
            TestGuy.AddComponent(fmc);
            TestGuy.AddComponent(dc);
            TestGuy.SetTag("Player");
            _Entities.AddEntity(TestGuy);


            PlayerTest TestGuy2 = new PlayerTest();
            TestGuy2.SetPosition(new Vector2(200, 200));
            Components.DrawComponent dc2 = new Components.DrawComponent(tgTex);
            Components.CollisionComponent cc2 = new Components.CollisionComponent();
            TestGuy2.AddComponent(cc2);
            TestGuy2.AddComponent(dc2);
            TestGuy2.SetTag("Other");
            _Entities.AddEntity(TestGuy2);
        }

        public override void Update()
        {
            base.Update();

            var p = _Entities.GetEntityByTag("Player");

            var tt = p._Components.Get<Components.CollisionComponent>();

            tt._BoundingBox.CheckCollision(_Entities.GetEntityByTag("Player")._Components.Get<Components.CollisionComponent>()._BoundingBox);

        }
    }
}
