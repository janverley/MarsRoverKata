using System.Collections.Generic;

namespace MarsRoverKata
{
    public record Point(int X, int Y);

    public enum Direction
    {
        N,
        S,
        E,
        W
    }


    public class Rover
    {
        public Point StartingPoint { get; set; } = new(0, 0);

        public Direction Heading { get; set; }

        public void Init(Point startingPoint, Direction heading)
        {
            StartingPoint = startingPoint;
            Heading = heading;
        }

        public void Execute(IEnumerable<Command> commands)
        {
        }
    }

    public enum Command
    {
        F,
        B,
        L,
        R
    }
}