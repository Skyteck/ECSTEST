using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ECSTEST.Scenes.TestScene1.Enums;

namespace ECSTEST.Scenes.TestScene1.GameObjects
{
    public class Item
    {
        public string _Name { get; set; }
        public double _Weight { get; set; } = 0;
        public int _SaleValue { get; set; } = 1;
        public Texture2D itemtexture { get; set; }
        public bool Stackable { get; protected set; } = false;
        public int Uses { get ; protected set; }
        public ItemID ID { get; protected set; } = 0;
        public int Amount { get; set; }
        public void Draw(SpriteBatch spritebatch, Vector2 Pos)
        {
            spritebatch.Draw(itemtexture, Pos, Color.White);
        }
    }
}
