namespace MarsRoverKata;

public record Point(double Latitude, double Longitude)
{
    public override string ToString()
    {
        return $"{SexagesimalAngle.FromDouble(Latitude).ToString("NS")}, {SexagesimalAngle.FromDouble(Longitude).ToString("WE")}";
    }

    public static Point Origin => new(0, 0);
    public static Point NorthPole => new(90, 0);
}