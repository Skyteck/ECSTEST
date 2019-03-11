using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Scenes;
using ECSTEST.Components;

namespace ECSTEST.Entitys
{
    public class EntityList
    {
        List<Entity> _Entities = new List<Entity>();
        List<Entity> _ToAdd = new List<Entity>();
        List<Entity> _ToRemove = new List<Entity>();

        public Scene _Scene { get; private set; }

        public EntityList(Scene s)
        {
            _Scene = s;
        }


        private void UpdateLists()
        {
            if (_ToAdd.Count > 0)
            {
                foreach (Entity c in _ToAdd)
                {
                    _Entities.Add(c);
                    c.AddToScene(_Scene);
                }
                _ToAdd.Clear();
            }

            if (_ToRemove.Count > 0)
            {
                foreach (Entity c in _ToRemove)
                {
                    _Entities.Remove(c);
                    c.RemovFromScene(_Scene);
                }
                _ToRemove.Clear();
            }
        }

        public void AddEntity(Entity c)
        {
            _ToAdd.Add(c);
        }

        public void RemoveEntity(Entity c)
        {
            _ToRemove.Add(c);
        }

        public void Update()
        {
            UpdateLists();

            foreach (Entity c in _Entities)
            {
                if (c._Active)
                {
                    c.Update();
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Entity c in _Entities)
            {
                if(c._Visible)
                {
                    c.Draw(sb);
                }
            }
        }

        public T Get<T>() where T : Entity
        {
            foreach (Entity c in _Entities)
            {
                if (c is T)
                {
                    return c as T;
                }
            }
            return null;
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            foreach (Entity c in _Entities)
            {
                if (c is T)
                {
                    yield return c as T;
                }
            }
        }

        public Entity GetEntityByTag(string t)
        {
            foreach(Entity e in _Entities)
            {
                if(e._Tag == t)
                {
                    return e;
                }
            }
            return null;
        }

        public T GetEntityComponentByTag<T>(string entityName) where T : Component
        {
            foreach (Entity c in _Entities)
            {
                if (c._Tag == entityName)
                {
                    return c._Components.GetComponent<T>();
                }
            }
            return null;
        }
    }
}
