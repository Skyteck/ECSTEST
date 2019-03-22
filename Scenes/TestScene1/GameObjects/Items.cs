using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Scenes.TestScene1.Enums;

namespace ECSTEST.Scenes.TestScene1.GameObjects
{
    class Fish : Item
    {
        public Fish()
        {
            this.ID = Enums.ItemID.kItemFish;
            this._Weight = 0;
            this._SaleValue = 1;
            this._Name = "Fish";
            this.Stackable = true;
        }
    }

    class Log : Item
    {
        public Log()
        {
            this.ID = Enums.ItemID.kItemLog;
            this._Weight = 1;
            this._SaleValue = 1;
            this._Name = "Log";
            this.Stackable = true;
        }
    }

    class Ore : Item
    {
        public Ore()
        {
            this.ID = Enums.ItemID.kItemOre;
            this._Weight = 2;
            this._SaleValue = 1;
            this._Name = "Ore";
        }
    }

    class CookedFish : Item
    {
        public CookedFish()
        {
            this.ID = Enums.ItemID.kItemMatches;
            this._Weight = 2;
            this._SaleValue = 1;
            this._Name = "CookedFish";
        }
    }

    class Matches : Item
    {
        public Matches()
        {
            this.ID = Enums.ItemID.kItemMatches;
            this._Weight = 2;
            this._SaleValue = 1;
            this._Name = "Matches";
            this.Uses = 5;
        }
    }

    class FishStick : Item
    {
        public FishStick()
        {
            this.ID = Enums.ItemID.kItemFishStick;
            this._Weight = 2;
            this._SaleValue = 1;
            this._Name = "FishStick";
        }
    }

    class Strawberry : Item
    {
        public Strawberry()
        {
            this.ID = Enums.ItemID.kItemStrawberry;
            this._Weight = 0;
            this._SaleValue = 1;
            this._Name = "Strawberry";
            this.Stackable = true;
        }
    }

    class SlimeGoo : Item
    {
        public SlimeGoo()
        {
            this.ID = Enums.ItemID.kItemSlimeGoo;
            this._Weight = 0;
            this._SaleValue = 1;
            this._Name = "Slime Goo";
            this.Stackable = true;
        }
    }
}
