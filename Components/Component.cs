using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Entitys;
using Microsoft.Xna.Framework.Graphics;
using ECSTEST.Scenes;

namespace ECSTEST.Components
{
    public class Component
    {
        public bool Active { get; internal set; } = true;
        public Entity _Entity { get; private set; }

        public Scene _Scene
        {
            get
            {
                if(_Entity != null)
                {
                    return _Entity._Scene;
                }
                else
                {
                    return null;
                }
            }
        }

        public void AddedTo(Entity entity)
        {
            _Entity = entity;
        }

        public void RemovedFrom(Entity entity)
        {
            _Entity = null;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }
    }
}
