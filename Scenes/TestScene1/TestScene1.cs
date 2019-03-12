using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Scenes.TestScene1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ECSTEST.Components;

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
            //_Content.RootDirectory = @"/Scenes/TestScene1";
            var tgTex = _Content.Load<Texture2D>(@"TestScene1\Art\TestGuy");
            
            TestGuy.AddComponent(new CollisionComponent());
            TestGuy.AddComponent(new KeyboardMoveComponent(200));
            TestGuy.AddComponent(new DrawComponent(tgTex));
            TestGuy._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            TestGuy.SetTag("Player");
            _Entities.AddEntity(TestGuy);


            PlayerTest TestGuy2 = new PlayerTest();
            TestGuy2.SetPosition(new Vector2(200, 200));
            TestGuy2.AddComponent(new CollisionComponent());
            TestGuy2.AddComponent(new DrawComponent(tgTex));
            TestGuy2._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            TestGuy2.SetTag("Other");
            _Entities.AddEntity(TestGuy2);
        }

        public override void Update()
        {
            base.Update();

        }
    }
}
