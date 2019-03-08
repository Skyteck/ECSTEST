using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Entitys;

namespace ECSTEST.Scenes
{
    public class Scene
    {
        protected ContentManager _Content;
        public string _Name { get; set; } = "Untitled";

        public bool _Active { get; set; }

        protected SceneManager _SM;
        public EntityList _Entities { get; private set; }
        //protected ArmadaCamera _Camera;
        public Scene(ContentManager c, SceneManager sm)
        {
            _Content = c;
            _SM = sm;
            _Entities = new EntityList(this);
        }

        public virtual void Init()
        {
            _Entities = new EntityList(this);
        }

        public virtual void LoadContent()
        {

        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Update()
        {
            InputHelper.Update();
            _Entities.Update();
        }

        public virtual void Draw(SpriteBatch sb, Rectangle b)
        {
            if (!_Active) return;
            _Entities.Draw(sb);
        }

        public void AddEntity(Entity e)
        {
            _Entities.AddEntity(e);
        }

        public void RemoveEntity(Entity e)
        {
            _Entities.RemoveEntity(e);
        }
    }
}