using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Entitys;

namespace ECSTEST.Components
{
    class GatherableComponent : Component
    {
        public float difficulty { get; private set; }
        public float respawnTime { get; private set; }

        CollisionComponent CollisionComponent;
        public override void AddedTo(Entity entity)
        {
            if(entity._Components.HasComponent<CollisionComponent>())
            {
                CollisionComponent = entity._Components.GetComponent<CollisionComponent>();
            }
            else
            {
                throw new Exception($"Missing Collision Component on {entity}");
            }
            base.AddedTo(entity);
        }

        public override void Update()
        {
            base.Update();

        }

    }
}
