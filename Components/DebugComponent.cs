using ECSTEST.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST.Components
{
    class DebugComponent : Component
    {
        Texture2D tex;
        bool hasRect = false;
        Rectangle collisionRect;

        public override void AddedTo(Entity entity)
        {
            if(entity._Components.HasComponent<CollisionComponent>())
            {
                //entity._Components.GetComponent<CollisionComponent>().
            }
            base.AddedTo(entity);
        }

        public void SetDebugTex(Texture2D t)
        {
            tex = t;
        }

        public override void Draw(SpriteBatch sb)
        {
            //HelperFunctions.DrawRectangleOutline
        }
    }
}
