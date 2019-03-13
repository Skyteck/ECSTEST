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

            Entitys.Entity TestGuy = new Entitys.Entity();
            //_Content.RootDirectory = @"/Scenes/TestScene1";
            var tgTex = _Content.Load<Texture2D>(@"TestScene1\Art\TestGuy");
            
            TestGuy.AddComponent(new CollisionComponent());
            TestGuy.AddComponent(new KeyboardMoveComponent(200));
            TestGuy.AddComponent(new DrawComponent(tgTex));
            TestGuy._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            TestGuy.SetTag("Player");
            _Entities.AddEntity(TestGuy);

            Entitys.Entity TestGuy2 = new Entitys.Entity();
            TestGuy2.SetPosition(new Vector2(200, 200));
            TestGuy2.AddComponent(new CollisionComponent());
            TestGuy2.AddComponent(new DrawComponent(tgTex));
            TestGuy2._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            TestGuy2.SetTag("Other");
            _Entities.AddEntity(TestGuy2);

            Entitys.Entity plantTest = new Entitys.Entity();
            plantTest.SetPosition(new Vector2(400, 400));
            plantTest.AddComponent(new CollisionComponent());
            plantTest.AddComponent(new GatherableComponent{ respawnTime = 5f});
            plantTest.AddComponent(new DrawComponent(tgTex));
            plantTest._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            plantTest.SetTag("TestPlant");
            _Entities.AddEntity(plantTest);
        }

        public override void Update()
        {
            base.Update();
            var playerbox = _Entities.GetEntityComponentByTag<CollisionComponent>("Player")._BoundingBox;
            var plantBox = _Entities.GetEntityComponentByTag<CollisionComponent>("TestPlant")._BoundingBox;

            if(playerbox.Intersects(plantBox))
            {
                _Entities.GetEntityComponentByTag<GatherableComponent>("TestPlant").GetGathered();
            }
        }
    }
}
