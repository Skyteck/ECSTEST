using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Scenes.TestScene1.GameObjects;
using ECSTEST.Scenes.TestScene1.Enums;

namespace ECSTEST.Scenes.TestScene1.Managers
{
    class InventoryManager
    {
        public int _Capacity = 28;

        List<Item> Items = new List<Item>(); 
        List<Item> _ToAdd = new List<Item>();
        List<Item> _ToRemove = new List<Item>();

        public bool AddItem<T>(int amt = 1) where T : Item, new()
        {
            bool success = false;
            var newItem = new T();

            foreach(Item i in Items)
            {
                if(i is T)
                {
                    if(i.Stackable) // item is in list already and stackable
                    {
                        i.Amount += amt;
                        amt = 0;
                        break;
                    }
                }
            }

            //item not in the list already so add it
            while(amt > 0 && Items.Count < _Capacity)
            {
                T nn = new T();
                Items.Add(nn);
                amt--;
            }

            return success;
        }

        public bool AddItem(ItemID newItemID, int amt = 1)
        {
            //check if item is in the list already
            Item itemInList = new Item();
            bool success = false;
            foreach(Item i in Items)
            {
                if(i.ID == newItemID)
                {
                    itemInList = i;
                }
            }

            //if it's not in the list already then add it
            if (itemInList.ID == 0) // item wasn't in the list
            {
                if(Items.Count < 28)
                {
                    if(itemInList.Stackable)
                    {
                        itemInList.Amount += amt;
                    }
                    else
                    {
                        while(Items.Count < 28 && amt > 0)
                        {
                            Item newItem = itemInList;
                            Items.Add(newItem);
                            amt--;
                        }
                    }
                }
            }
            //if it's in the list and stackable then increment by 1
            else if(itemInList.Stackable)
            {
                itemInList.Amount += amt;
            }
            //if it's in the list but not stackable then add a new one
            else if(itemInList.ID != 0)
            {
                if (Items.Count < 28)
                {
                    while (Items.Count < 28 && amt > 0)
                    {
                        Item newItem = itemInList;
                        Items.Add(newItem);
                        amt--;
                    }
                }
            }

            return success;
        }

        public void ListItems()
        {
            foreach(Item i in Items)
            {
                Console.WriteLine($"{i._Name} {i.Amount}");
            }
        }
    }
}
