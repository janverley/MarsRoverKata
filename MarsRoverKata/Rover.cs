using System.Collections.Generic;

namespace MarsRoverKata
{
    public static class DirectionExtensions
    {
        public static Direction Inverse(this Direction input)
        {
            switch (input)
            {
                case Direction.N:
                    return Direction.S;
                case Direction.S:
                    return Direction.N;
                case Direction.E:
                    return Direction.W;
                case Direction.W:
                    return Direction.E;
                default:
                    throw new InvalidOperationException($"Unknown Direction {input}");
            }
        }
        public static Direction ClockWise(this Direction input)
        {
            switch (input)
            {
                case Direction.N:
                    return Direction.W;
                case Direction.S:
                    return Direction.E;
                case Direction.E:
                    return Direction.N;
                case Direction.W:
                    return Direction.S;
                default:
                    throw new InvalidOperationException($"Unknown Direction {input}");
            }
        }

        public static Direction CounterClockWise(this Direction input)
        {
            switch (input)
            {
                case Direction.N:
                    return Direction.E;
                case Direction.S:
                    return Direction.W;
                case Direction.E:
                    return Direction.S;
                case Direction.W:
                    return Direction.N;
                default:
                    throw new InvalidOperationException($"Unknown Direction {input}");
            }
        }
    }

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
            foreach (var command in commands)
            {
                switch (command)
                {
                    case Command.F:
                        CurrentPosition = Mars.Move(CurrentPosition, CurrentHeading);
                        CurrentHeading = Mars.WouldWrapAtNorthPole(CurrentPosition, CurrentHeading) ? CurrentHeading.Inverse() : CurrentHeading;
                        break;
                    case Command.B:
                        CurrentPosition = Mars.Move(CurrentPosition, CurrentHeading.Inverse());
                        CurrentHeading = Mars.WouldWrapAtNorthPole(CurrentPosition, CurrentHeading.Inverse()) ? CurrentHeading.Inverse() : CurrentHeading;
                        break;
                    case Command.L:
                        CurrentHeading = CurrentHeading.ClockWise();
                        break;
                    case Command.R:
                        CurrentHeading = CurrentHeading.CounterClockWise();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}