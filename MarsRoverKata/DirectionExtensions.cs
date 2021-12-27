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
}