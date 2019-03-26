using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Entitys;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ECSTEST.Components
{
    class CollisionComponent : Component
    {
        BoundingBox _BoundingBox { get; set; }
        Texture2D debugTex;

        public CollisionComponent()
        {

        }

        public void SetDebugTex(Texture2D t)
        {
            debugTex = t;
        }

        public override void AddedTo(Entity entity)
        {
            base.AddedTo(entity);
            _BoundingBox = new BoundingBox(entity._Position, entity._Size.X, entity._Size.Y);
        }

        public bool Intersects(CollisionComponent bb)
        {
            if (!Active || !bb.Active) return false;
            return _BoundingBox.Intersects(bb._BoundingBox);
        }

        public override void Update()
        {
            base.Update();
            _BoundingBox._Position = _Entity._Position;
        }

        public override void Draw(SpriteBatch sb)
        {
            HelperFunctions.DrawRectangleOutline(sb, _BoundingBox.ToRectangle(), debugTex, Color.White);
        }
    }
}
