namespace MarsRoverKata;

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
    public void Init(Point startingPoint, Direction heading)
    {
        StartingPoint = startingPoint;
        Heading = heading;
    }

    public Point StartingPoint { get; set; } = new Point(0, 0);

    public Direction Heading { get; set; }
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