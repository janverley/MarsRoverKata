namespace MarsRoverKata
{
    public class Rover
    {
        public override string ToString()
        {
            return $"H:{CurrentHeading} P:{CurrentPosition}";
        }

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
                Direction newHeading;
                switch (command)
                {
                    case Command.F:
                        newHeading = Mars.WouldWrapAtNorthPole(CurrentPosition, CurrentHeading) ? CurrentHeading.Inverse() : CurrentHeading;
                        CurrentPosition = Mars.Move(CurrentPosition, CurrentHeading);
                        CurrentHeading = newHeading;
                        break;
                    case Command.B:
                        newHeading = Mars.WouldWrapAtNorthPole(CurrentPosition, CurrentHeading.Inverse()) ? CurrentHeading.Inverse() : CurrentHeading;
                        CurrentPosition = Mars.Move(CurrentPosition, CurrentHeading.Inverse());
                        CurrentHeading = newHeading;
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