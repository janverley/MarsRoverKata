using System.Security.Cryptography;

namespace MarsRoverKata;

public static class Mars
{
    public static decimal Radius = 3389.50m * 1000m;
    public static int EquatorLength = 10; // wrap on x axis
    public static int NorthPoleToEquatorDistance = 5; // wrap on y axis

    private static Point WrapAtNorthPole(this Point start)
    {
        if (start.longitude > NorthPoleToEquatorDistance)
        {
            return new Point(start.latitude + (EquatorLength / 2m), NorthPoleToEquatorDistance - (start.longitude - NorthPoleToEquatorDistance));
        }
        else
        {
            return start;
        }
    }
    
    public static Point Move(Point start, Direction direction)
    {
        switch (direction)
        {
            case Direction.N:
                return WrapAtNorthPole(new Point(start.latitude + 0, start.longitude + 1));
            case Direction.S:
                return WrapAtNorthPole(new Point(start.latitude - 0, start.longitude - 1));
            case Direction.E:
                return WrapAtNorthPole(new Point(start.latitude + 1, start.longitude + 0));
            case Direction.W:
                return WrapAtNorthPole(new Point(start.latitude -1, start.longitude - 0));

            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public static bool WouldWrapAtNorthPole(Point currentPosition, Direction currentHeading)
    {
        return false; // todo
    }
}