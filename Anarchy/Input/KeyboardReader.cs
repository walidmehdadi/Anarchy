﻿using Anarchy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anarchy.Input
{
    class KeyboardReader : IInputReader
    {
        public bool isDestinationInput => false;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
            }
            return direction;
        }
    }
}
