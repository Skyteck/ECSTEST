using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSTEST.Entitys;
using Microsoft.Xna.Framework.Graphics;

namespace ECSTEST.Components
{
    public class ComponentList
    {
        List<Component> _Components = new List<Component>();
        List<Component> _toAdd = new List<Component>();
        List<Component> _toRemove = new List<Component>();

        public Entity _Entity { get; }
        public ComponentList(Entity entity)
        {
            _Entity = entity;
        }

        private void UpdateLists()
        {
            if(_toAdd.Count > 0)
            {
                foreach(Component c in _toAdd)
                {
                    _Components.Add(c);
                    c.AddedTo(_Entity);
                }
                _toAdd.Clear();
            }

            if(_toRemove.Count > 0)
            {
                foreach(Component c in _toRemove)
                {
                    _Components.Remove(c);
                    c.RemovedFrom(_Entity);
                }
                _toRemove.Clear();
            }
        }

        public void AddComponent(Component c)
        {
            _toAdd.Add(c);
        }

        public void RemoveComponent(Component c)
        {
            _toRemove.Add(c);
        }

        public void Update()
        {
            UpdateLists();

            foreach(Component c in _Components)
            {
                if(c.Active)
                {
                    c.Update();
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach(Component c in _Components)
            {
                if (c.Active)
                {
                    c.Draw(sb);
                }
            }
        }

        public T Get<T>() where T : Component
        {
            foreach(Component c in _Components)
            {
                if(c is T)
                {
                    return c as T;
                }
            }
            return null;
        }

        public IEnumerable<T> GetAll<T>() where T : Component
        {
            foreach(Component c in _Components)
            {
                if(c is T)
                {
                    yield return c as T;
                }
            }
        }
    }
}
