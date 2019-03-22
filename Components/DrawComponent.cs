using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSTEST.Components
{
    internal class DrawComponent : Component
    {
        public bool Visible { get; internal set; } = true;
        public Vector2 _Offset { get; set; } = Vector2.Zero;

        public DrawComponent()
        { 
        
        }

        public Vector2 _DrawPosition
        {
            get
            {
                return _Entity._Position + _Offset;
            }
        }

        public Texture2D _Texture
        {
            get
            {
                if(_Entity.Texture != null)
                {
                    return _Entity.Texture;
                }
                else
                {
                    return null;
                }
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            if(Visible)
            {
                sb.Draw(_Texture, _DrawPosition, Color.White);
            }
        }
    }
}