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
using ECSTEST.Scenes.TestScene1.Managers;
using ECSTEST.Scenes.TestScene1.Enums;

namespace ECSTEST.Scenes
{
    public class TestScene1Scene : Scene
    {
        CollisionComponent playerBox;
        InventoryManager _InventoryManager = new InventoryManager();

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

            //playerBox = TestGuy._Components.GetComponent<CollisionComponent>()._BoundingBox;

            Entitys.Entity TestGuy2 = new Entitys.Entity();
            TestGuy2.SetPosition(new Vector2(200, 200));

            CollisionComponent playerCollision = new CollisionComponent();
            TestGuy2.AddComponent(playerCollision);
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


            _Entities.FinishComponentsSetup();

            
        }

        public override void Update()
        {
            base.Update();
            if(playerBox == null)
            {
                playerBox = _Entities.GetEntityComponentByTag<CollisionComponent>("Player");
            }
            var plantBox = _Entities.GetEntityComponentByTag<CollisionComponent>("TestPlant");

            if(playerBox.Intersects(plantBox))
            {
                _Entities.GetEntityComponentByTag<GatherableComponent>("TestPlant").GetGathered();
                _InventoryManager.AddItem<TestScene1.GameObjects.Log>(2);
                _InventoryManager.ListItems();
                //Console.WriteLine("dd");
            }
        }
    }
}
