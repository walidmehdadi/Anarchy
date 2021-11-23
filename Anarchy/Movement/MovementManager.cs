using Anarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anarchy.Movement
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.isDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }
            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;
            if ((futurePosition.X < (1500-56) && futurePosition.X > 0))
            {
                movable.Position = futurePosition;
                movable.Position += distance;
            }
        }
    }
}
