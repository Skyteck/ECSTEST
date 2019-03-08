using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSTEST.Components
{
    internal class DrawComponent : Component
    {
        public bool Visible { get; internal set; } = true;
        public Vector2 _Offset { get; set; } = Vector2.Zero;

        public DrawComponent(Texture2D tex)
        {
            _Texture = tex;
        }

        public Vector2 _DrawPosition
        {
            get
            {
                return _Entity._Position + _Offset;
            }
        }

        public Texture2D _Texture;

        public override void Draw(SpriteBatch sb)
        {
            if(Visible)
            {
                sb.Draw(_Texture, _DrawPosition, Color.White);
            }
        }
    }
}