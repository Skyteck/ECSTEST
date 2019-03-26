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
using ECSTEST.Scenes.TestScene1.Entitys;
using ECSTEST.Entitys;
using ECSTEST.Scenes.TestScene1.GameObjects;
namespace ECSTEST.Scenes
{
    public class TestScene1Scene : Scene
    {
        CollisionComponent playerBox;
        InventoryManager _InventoryManager = new InventoryManager();
        private TiledMap map;
        private TiledMapRenderer mapRenderer;
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
            Texture2D tgTex = _Content.Load<Texture2D>(@"TestScene1\Art\TestGuy");
            map = _Content.Load<TiledMap>(@"TestScene1\TileMaps\Map1");
            CollisionComponent playercollision = new CollisionComponent();



            playercollision.SetDebugTex(Game1.debugTex);

            TestGuy.AddComponent(playercollision);
            TestGuy.AddComponent(new KeyboardMoveComponent(200));
            TestGuy.AddComponent(new DrawComponent());

            TestGuy.SetTexture(tgTex);
            TestGuy._Size = new Vector2(tgTex.Bounds.Width, tgTex.Bounds.Height);
            TestGuy.SetTag("Player");
            TiledMapObjectLayer hmm = map.ObjectLayers.Where(x => x.Name == "Object Layer 1").First();
            TiledMapObject hmm2 = hmm.Objects.Where(x => x.Name == "PlayerSpawn").First();
            Vector2 hmm3 = hmm2.Position;
            TestGuy.SetPosition(hmm3);
            _Entities.AddEntity(TestGuy);


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
                        if(obj.Type == "Tree")
                        {
                            Texture2D tex = _Content.Load<Texture2D>(@"TestScene1\Art\TestGuy");
                            Entity newe = _Entities.CreateEntityAndReturn<Tree>(tex, obj.Position);
                            newe.SetTag(obj.Name);
                            newe._Size = new Vector2(tex.Width, tex.Height);
                            newe.SetTexture(tex);
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

                        Random ran = new Random();
                        int n = ran.Next();

                        if((n % 2) == 0)
                        {
                            _InventoryManager.AddItem<Log>();

                        }
                        else
                        {
                            _InventoryManager.AddItem<SlimeGoo>();
                        }

                        _InventoryManager.ListItems();
                    }
                }
            }
        }

        public override void Draw(SpriteBatch sb, Rectangle b)
        {
            mapRenderer.Draw(map);
            base.Draw(sb, b);
        }
    }
}
