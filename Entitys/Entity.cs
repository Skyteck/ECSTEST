using ECSTEST.Components;
using ECSTEST.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST.Entitys
{
    public class Entity
    {
        public bool _Active { get; set; } = true;
        public bool _Visible { get; set; } = true;
        public Vector2 _Position { get; private set; }
        public Vector2 _Size { get; set; }
        public Scene _Scene { get; set; }
        public ComponentList _Components { get; private set; } 
        public string _Tag { get; private set; }
        public Texture2D Texture { get; internal set; }

        public Entity(Vector2 position)
        {
            _Position = position;
            _Components = new ComponentList(this);
        }

        public Entity() : this(Vector2.Zero)
        {
            _Visible = false;
        }

        public void SetPosition(Vector2 pos)
        {
            _Position = pos;
            _Visible = true;
        }

        public void SetTexture(Texture2D tex)
        {
            Texture = tex;
        }

        public virtual void Update()
        {
            _Components.Update();
        }

        public virtual void Draw(SpriteBatch sb)
        {
            _Components.Draw(sb);
        }

        public virtual void AddToScene(Scene s)
        {
            _Scene = s;
        }

        public virtual void RemovFromScene(Scene s)
        {
            _Scene = null;
        }

        public void AddComponent(Component c)
        {
            _Components.AddComponent(c);
        }

        public void RemoveComponent(Component c)
        {
            _Components.RemoveComponent(c);
        }

        public void SetTag(string t)
        {
            _Tag = t;
        }
    }
}
