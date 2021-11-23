﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anarchy.Animation
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
