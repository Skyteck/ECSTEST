using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST
{
    class BoundingBox
    {
        public Vector2 _Position { get; set; }
        public float _Height { get; set; }
        public float _Width { get; set; }

        public float _Top
        {
            get
            {
                return this._Position.Y;
            }
        }

        public float _Bottom
        {
            get
            {
                return this._Position.Y + _Height;
            }
        }

        public float _Left
        {
            get
            {
                return this._Position.X;
            }
        }

        public float _Right
        {
            get
            {
                return this._Position.X + _Width;
            }
        }

        public Vector2 _TopLeft
        {
            get
            {
                return new Vector2(_Top, _Left);
            }
        }

        public Vector2 _TopRight
        {
            get
            {
                return new Vector2(_Top, _Right);
            }
        }

        public Vector2 _BottomLeft
        {
            get
            {
                return new Vector2(_Bottom, _Left);
            }
        }

        public Vector2 _BottomRight
        {
            get
            {
                return new Vector2(_Bottom, _Right);
            }
        }

        public BoundingBox(Vector2 pos, float width, float height)
        {
            _Position = pos;
            _Width = width;
            _Height = height;
        }

        public bool CheckCollision(BoundingBox OtherBB)
        {
            if(_Left < OtherBB._Right && _Right > OtherBB._Left && _Top < OtherBB._Bottom && _Bottom > OtherBB._Top)
            {
                Console.WriteLine("Collision!!!!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle((int)_Left, (int)_Top, (int)_Width, (int)_Height);
        }
    }
}
