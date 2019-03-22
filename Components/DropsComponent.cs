using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Scenes.TestScene1.GameObjects;
namespace ECSTEST.Components
{
    class DropsComponent : Component
    {
        List<Item> Drops = new List<Item>(100);
        List<ItemDrop> itemDrops = new List<ItemDrop>();
        public DropsComponent()
        {

        }

        public void AddDrop(Item i, int rarity)
        {
            new ItemDrop { Item = i, rarity = rarity };

        }
    }

    struct ItemDrop
    {
        public Item Item;
        public int rarity;
    }
}
