using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST.Components
{
    class FollowMouseComponent : Component
    {
        public Vector2 Offset { get; set; } = Vector2.Zero;
        public override void Update()
        {
            base.Update();
            _Entity.SetPosition(InputHelper.MouseScreenPos + Offset);
        }
    }
}
