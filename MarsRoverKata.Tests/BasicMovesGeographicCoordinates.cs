using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace MarsRoverKata.Tests;

public class BasicMovesGeographicCoordinates

{
    private readonly ITestOutputHelper testOutputHelper;

    public BasicMovesGeographicCoordinates(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    private Rover InitialRover()
    {
        var result = new Rover();
        result.Init(Point.Origin, Direction.N);
        return result;
    }

    [Fact]
    public void AfterInitCurrentPositionAndHeadingShouldMatch()
    {
        var sut = InitialRover();
        sut.CurrentPosition.ShouldBe(new Point(0,0));
        sut.CurrentHeading.ShouldBe(Direction.N);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void After1Forward_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.F });

        var lat = 360 / (Math.Tau * Mars.Radius);
        sut.CurrentPosition.ShouldBe(new Point(lat, 0));
        sut.CurrentHeading.ShouldBe(Direction.N);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void AfterwholePlanetToNorth_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();

        
        var commands = new List<Command>();

        var dist = Mars.Radius * Math.Tau;
        for (int i = 0; i < dist; i++)
        {
            commands.Add(Command.F);
        }
        sut.Execute(commands);

        testOutputHelper.WriteLine(sut.ToString());
        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.Origin).ToString());
        sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBeLessThan(1);

        sut.CurrentHeading.ShouldBe(Direction.N);
    }

    [Fact]
    public void AfterHalfPlanetToNorth_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();

        
        var commands = new List<Command>();

        var dist = Mars.Radius * Math.Tau / 4;
        for (int i = 0; i < dist; i++)
        {
            commands.Add(Command.F);
        }
        sut.Execute(commands);

        testOutputHelper.WriteLine(sut.ToString());
        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.Origin).ToString());
        sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBe(5324215, 1);
        sut.CurrentPosition.Diff(Point.NorthPole).ArcLength().ShouldBe(0, 1);

        sut.CurrentHeading.ShouldBe(Direction.N);
    }

    [Fact]
    public void AfterHalfWayToNorth_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        
        var commands = new List<Command>();

        var dist = Mars.Radius * Math.Tau / 8;
        for (int i = 0; i < dist; i++)
        {
            commands.Add(Command.F);
        }
        sut.Execute(commands);

        testOutputHelper.WriteLine(sut.ToString());
        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.Origin).ToString());
        sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBe(2662107.1, 1);
        sut.CurrentPosition.Diff(Point.NorthPole).ArcLength().ShouldBe(2662107.1, 1);

        sut.CurrentHeading.ShouldBe(Direction.N);
    }

    [Fact]
    public void After1Back_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.B });

        var lat = -360 / (Math.Tau * Mars.Radius);
        sut.CurrentPosition.ShouldBe(new Point(lat, 0));
        sut.CurrentHeading.ShouldBe(Direction.N);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void After1Left_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.L });

        sut.CurrentPosition.ShouldBe(new Point(0, 0));
        sut.CurrentHeading.ShouldBe(Direction.W);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void After1Right_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.R });

        sut.CurrentPosition.ShouldBe(new Point(0,0));
        sut.CurrentHeading.ShouldBe(Direction.E);
        testOutputHelper.WriteLine(sut.ToString());
    }


    [Fact]
    public void After1Left1Forward_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.L, Command.F });

        var @long = -360 / (Math.Tau * Mars.Radius);

        sut.CurrentPosition.ShouldBe(new Point(0, @long));
        sut.CurrentHeading.ShouldBe(Direction.W);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void After4Left_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.L, Command.L, Command.L, Command.L });

        sut.CurrentPosition.ShouldBe(new Point(0, 0));
        sut.CurrentHeading.ShouldBe(Direction.N);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void After4Moves_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> { Command.F, Command.R, Command.F, Command.R, Command.F, Command.R, Command.F, Command.R });

        sut.CurrentPosition.IsSame(new Point(0, 0)).ShouldBeTrue();
        sut.CurrentHeading.ShouldBe(Direction.N);
        testOutputHelper.WriteLine(sut.ToString());
    }

    [Fact]
    public void AfterALotOf4Moves_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();

        var commands = new List<Command>();
        for (int i = 0; i < 1000000; i++)
        {
            commands.Add(Command.F);
            commands.Add(Command.R);
        }
        
        sut.Execute(commands);
        testOutputHelper.WriteLine(sut.ToString());

        sut.CurrentHeading.ShouldBe(Direction.N);

        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength().ToString());

        sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBeLessThan(0.0001);
        
    }

    [Fact]
    public void After4LongMoves_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();

        var commands = new List<Command>();

        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 1000; i++)
            {
                commands.Add(Command.F);
            }
            commands.Add(Command.R);
        }

        sut.Execute(commands);
        testOutputHelper.WriteLine(sut.ToString());

        sut.CurrentHeading.ShouldBe(Direction.N);

        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength().ToString());

        sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBeLessThan(0.2);
        
    }

    [Fact]
    public void AfterLongMove_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();

        var commands = new List<Command>();

            for (int i = 0; i < 1000; i++)
            {
                commands.Add(Command.F);
            }

        sut.Execute(commands);
        testOutputHelper.WriteLine(sut.ToString());

        sut.CurrentHeading.ShouldBe(Direction.N);

        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength().ToString());

        Math.Abs(1000 - sut.CurrentPosition.Diff(Point.Origin).ArcLength()).ShouldBeLessThan(0.01);
    }

    [Fact]
    public void AfterTravelOVerNorthPole_PositionAndHeadingShouldBeCorrect()
    {
        var sut = new Rover();
        sut.Init(new Point(89.99, 10), Direction.N);

        testOutputHelper.WriteLine(sut.ToString());
        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.NorthPole).ToString());
        
        var commands = new List<Command>();

        for (int i = 0; i <1000; i++)
        {
            commands.Add(Command.F);
        }

        sut.Execute(commands);
        testOutputHelper.WriteLine(sut.ToString());
        testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.NorthPole).ToString());

        sut.CurrentHeading.ShouldBe(Direction.S);
        Math.Abs(1000 - sut.CurrentPosition.Diff(Point.Origin).ArcLength()).ShouldBeLessThan(0.01);
    }

}