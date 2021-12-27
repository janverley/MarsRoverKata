namespace MarsRoverKata
{
    public static class Mars
    {
        public static decimal Radius = 3389.50m * 1000m;
        public static int EquatorLength = 10; // wrap on x axis
        public static int NorthPoleToEquatorDistance = 5; // wrap on y axis

        private static bool ShouldWrapAtNorthPole(this Point start)
        {
            return start.longitude > NorthPoleToEquatorDistance;
        }

        private static bool ShouldWrapAtEquator(this Point start)
        {
            return start.latitude > EquatorLength;
        }

        private static Point WrapAtNorthPole(this Point start)
        {
            return start.ShouldWrapAtNorthPole()
                ? new Point(start.latitude + EquatorLength / 2m, NorthPoleToEquatorDistance - (start.longitude - NorthPoleToEquatorDistance))
                : start;
        }

        public static Point Move(Point start, Direction direction)
        {
            return WrapAtEquator(WrapAtNorthPole(InternalMove(start, direction)));
        }

        private static Point WrapAtEquator(Point start)
        {
            return start.ShouldWrapAtEquator()
                ? new Point(start.latitude - EquatorLength, start.longitude)
                : start;
        }

        private static Point InternalMove(Point start, Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    return new Point(start.latitude + 0, start.longitude + 1);
                case Direction.S:
                    return new Point(start.latitude - 0, start.longitude - 1);
                case Direction.E:
                    return new Point(start.latitude + 1, start.longitude + 0);
                case Direction.W:
                    return new Point(start.latitude - 1, start.longitude - 0);

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public static bool WouldWrapAtNorthPole(Point currentPosition, Direction currentHeading)
        {
            return InternalMove(currentPosition, currentHeading).ShouldWrapAtNorthPole();
        }
    }
}