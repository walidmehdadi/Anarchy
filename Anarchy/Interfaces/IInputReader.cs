using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anarchy.Interfaces
{
    public interface IInputReader
    {
        Vector2 ReadInput();
        public bool isDestinationInput { get; }
    }
}
