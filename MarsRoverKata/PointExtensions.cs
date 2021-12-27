namespace MarsRoverKata
{
    public static class PointExtensions
    {
        public static Point Diff(this Point point, Point other)
        {
            return new Point(Math.Abs( point.Latitude - other.Latitude),Math.Abs(  point.Longitude - other.Longitude));
        }

        public static double ArcLength(this Point point)
        {
            return ArcLength(point, Point.Origin);
        }

        public static double ArcLength(this Point point, Point other)
        {
            var theta1 =  ( point.Longitude)*Math.PI / 180;
            var phi1 = (90 - point.Latitude)*Math.PI / 180;

            var theta2 =  ( other.Longitude)*Math.PI / 180;
            var phi2 = (90 - other.Latitude)*Math.PI / 180;

            var x1 =  Mars.Radius* Math.Sin(phi1 ) * Math.Cos(theta1 );
            var y1 =  Mars.Radius*Math.Sin(phi1 ) * Math.Sin(theta1 );
            var z1 =  Mars.Radius*Math.Cos(phi1 );
        
            var x2 =  Mars.Radius*Math.Sin(phi2 ) * Math.Cos(theta2 );
            var y2 =  Mars.Radius*Math.Sin(phi2 ) * Math.Sin(theta2 );
            var z2 =  Mars.Radius*Math.Cos(phi2 );

            var modV1 = Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);
            var modV2 = Math.Sqrt(x2 * x2 + y2 * y2 + z2 * z2);

            var dotProductV1V2 = x1 * x2 + y1 * y2 + z1 * z2;

            var alphaRad = Math.Acos(dotProductV1V2 / (modV1 * modV2));
        
            return alphaRad * Mars.Radius;
        }


        public static bool IsSame(this Point point, Point other)
        {
            return Close(point.Latitude, other.Latitude) &&
                   Close(point.Longitude, other.Longitude);
        }

        private static bool Close(double d, double o)
        {
            return Math.Abs(d - o) < 0.0000000000001;
        }
        
        public static double UnWrap(this double angleInDegrees)
        {
            //ensure the value will fall within the primary range [-180.0..+180.0]
            while (angleInDegrees < -180.0)
                angleInDegrees += 360.0;

            while (angleInDegrees > 180.0)
                angleInDegrees -= 360.0;

            return angleInDegrees;
        }

    }
}