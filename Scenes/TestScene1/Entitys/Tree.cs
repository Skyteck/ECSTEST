using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Components;
using ECSTEST.Entitys;

namespace ECSTEST.Scenes.TestScene1.Entitys
{
    class Tree : Entity
    {
        public Tree()
        {
            AddComponent(new CollisionComponent());
            AddComponent(new GatherableComponent { respawnTime = 5f });
            AddComponent(new DrawComponent());
        }
    }
}
