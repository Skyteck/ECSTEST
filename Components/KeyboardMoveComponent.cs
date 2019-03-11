using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECSTEST.Components
{
    class KeyboardMoveComponent : Component
    {
        public float Speed;

        public KeyboardMoveComponent(float speed)
        {
            Speed = speed;
        }

        public override void Update()
        {
            base.Update();
            Vector2 newPos = _Entity._Position;
            if (InputHelper.IsKeyDown(Keys.W))
            {
                newPos.Y -= Speed * Game1.DeltaTime;
            }
            else if(InputHelper.IsKeyDown(Keys.S))
            {
                newPos.Y += Speed * Game1.DeltaTime;

            }
            if (InputHelper.IsKeyDown(Keys.A))
            {
                newPos.X -= Speed * Game1.DeltaTime;
            }
            else if (InputHelper.IsKeyDown(Keys.D))
            {
                newPos.X += Speed * Game1.DeltaTime;
            }
            _Entity.SetPosition(newPos);
        }
    }
}
