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
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;

namespace ECSTEST.Scenes
{
    public class TestScene1Scene : Scene
    {
        CollisionComponent playerBox;
        InventoryManager _InventoryManager = new InventoryManager();
        private TiledMap map;
        private TiledMapRenderer mapRenderer;
        Texture2D tgTex;
        public TestScene1Scene(ContentManager contentManager, SceneManager sceneManager) : base(contentManager, sceneManager)
        {
            this._Name = "Test Scene 1";
            mapRenderer = new TiledMapRenderer(sceneManager.GraphicsDevice);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            Entitys.Entity TestGuy = new Entitys.Entity();
            //_Content.RootDirectory = @"/Scenes/TestScene1";
            tgTex = _Content.Load<Texture2D>(@"TestScene1\Art\TestGuy");
            map = _Content.Load<TiledMap>(@"TestScene1\TileMaps\Map1");
            TestGuy.AddComponent(new CollisionComponent());
            TestGuy.AddComponent(new KeyboardMoveComponent(200));
            TestGuy.AddComponent(new DrawComponent(tgTex));
            TestGuy._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            TestGuy.SetTag("Player");
            TiledMapObjectLayer hmm = map.ObjectLayers.Where(x => x.Name == "Object Layer 1").First();
            TiledMapObject hmm2 = hmm.Objects.Where(x => x.Name == "PlayerSpawn").First();
            Vector2 hmm3 = hmm2.Position;
            TestGuy.SetPosition(hmm3);
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

            LoadMapObjects(map);

            _Entities.FinishComponentsSetup();

            
        }

        public void LoadMapObjects(TiledMap testMap)
        {
            List<TiledMapObjectLayer> LayerList = testMap.ObjectLayers.ToList();
            if (LayerList != null)
            {
                foreach (TiledMapObjectLayer layer in LayerList)
                {
                    foreach(TiledMapObject obj in layer.Objects)
                    {
                        Entitys.Entity newe = new Entitys.Entity(obj.Position);

                        if(obj.Type == "Tree")
                        {
                            newe.AddComponent(new CollisionComponent());
                            newe.AddComponent(new GatherableComponent { respawnTime = 5f });
                            newe.AddComponent(new DrawComponent(tgTex));
                            newe.SetTag(obj.Name);
                            newe.SetPosition(obj.Position);
                            newe._Size = new Vector2(tgTex.Width, tgTex.Height);
                            _Entities.AddEntity(newe);
                        }
                    }
                }
            }
        }

        public override void Update()
        {
            base.Update();
            if(playerBox == null)
            {
                playerBox = _Entities.GetEntityComponentByTag<CollisionComponent>("Player");
            }

            var trees = _Entities.GetAllEntitysByTag("Tree");

            foreach(Entitys.Entity e in trees)
            {
                if(e._Components.HasComponent<GatherableComponent>())
                {
                    if(e._Components.GetComponent<CollisionComponent>().Intersects(playerBox))
                    {
                        e._Components.GetComponent<GatherableComponent>().GetGathered();
                        _InventoryManager.ListItems();
                    }
                }
            }
        }

        public override void Draw(SpriteBatch sb, Rectangle b)
        {
            base.Draw(sb, b);
            mapRenderer.Draw(map);
        }
    }
}
