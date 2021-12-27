namespace MarsRoverKata
{
    public static class Mars
    {
        public const double Radius = 3389.50 * 1000;

        public static Point Move(Point start, Direction direction)
        {
            double latDiff = 0;
            double longDiff = 0;
            var radiusAtLat = Math.Cos(start.Latitude * Math.Tau / 360) * Radius;

            switch (direction)
            {
                case Direction.N:
                {
                     latDiff = 360 / (Math.Tau * Radius);
                     break;
                }
                case Direction.S:
                {
                     latDiff = - 360 / (Math.Tau * Radius);
                     break;
                }
                case Direction.E:
                { 
                    longDiff = 360 / (Math.Tau * radiusAtLat);
                    break;
                }
                case Direction.W:
                {
                     longDiff = - 360 / (Math.Tau * radiusAtLat);
                     break;
                }
            }
            return new Point(start.Latitude + latDiff, start.Longitude + longDiff);
        }

        public static bool WouldWrapAtNorthPole(Point currentPosition, Direction currentHeading)
        {
            return false; // todo
            //return InternalMove(currentPosition, currentHeading).ShouldWrapAtNorthPole();
        }
    }
}