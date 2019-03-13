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
        public float respawnTime { get; set; }
        public float countdowntoRespawn { get; private set; }
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
            if(countdowntoRespawn > 0f)
            {
                countdowntoRespawn -= Game1.DeltaTime;
                if(countdowntoRespawn <= 0f)
                {
                    _Entity._Visible = true;
                    CollisionComponent.Active = true;

                }
            }
        }

        public void GetGathered()
        {
            _Entity._Visible = false;
            CollisionComponent.Active = false;
            countdowntoRespawn = respawnTime;
        }

    }
}
