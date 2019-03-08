using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST.Components
{
    public class TransformComponent : Component
    {
        public Vector2 _Position { get; private set; }

        public Vector2 _Scale { get; private set; }
    }
}
