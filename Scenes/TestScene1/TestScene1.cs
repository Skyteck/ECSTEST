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
            TestGuy.AddComponent(fmc);
            TestGuy.AddComponent(dc);
            _Entities.AddEntity(TestGuy);
        }
    }
}
