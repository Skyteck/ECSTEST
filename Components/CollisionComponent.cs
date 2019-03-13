using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Entitys;

namespace ECSTEST.Components
{
    class CollisionComponent : Component
    {
        public BoundingBox _BoundingBox { get; private set; }
        
        public CollisionComponent()
        {

        }

        public override void AddedTo(Entity entity)
        {
            base.AddedTo(entity);
            _BoundingBox = new BoundingBox(entity._Position, entity._Size.X, entity._Size.Y);
        }

        public override void Update()
        {
            base.Update();
            _BoundingBox._Position = _Entity._Position;
        }
    }
}
