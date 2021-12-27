namespace MarsRoverKata
{
    public static class Mars
    {
        public static double Radius = 3389.50 * 1000;
        //public static int EquatorLength = 10; // wrap on x axis
        //public static int NorthPoleToEquatorDistance = 5; // wrap on y axis

        // private static bool ShouldWrapAtNorthPole(this Point start)
        // {
        //     return start.Longitude > NorthPoleToEquatorDistance;
        // }
        //
        // private static bool ShouldWrapAtEquator(this Point start)
        // {
        //     return start.Latitude > EquatorLength;
        // }

        public static Point Move(Point start, Direction direction)
        {
            return InternalMove(start, direction);
        }

        private static Point InternalMove(Point start, Direction direction)
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