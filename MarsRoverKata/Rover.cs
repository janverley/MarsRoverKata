using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Rover
    {
        public Point CurrentPosition { get; private set; } = new(0, 0);

        public Direction CurrentHeading { get; private set; }

        public void Init(Point startingPoint, Direction heading)
        {
            CurrentPosition = startingPoint;
            CurrentHeading = heading;
        }

        public void Execute(IEnumerable<Command> commands)
        {
        }
    }
}