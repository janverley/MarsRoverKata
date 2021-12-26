using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace MarsRoverKata.Tests;

public class BasicMoves
    
{
    private Rover InitialRover()
    {
        var result = new Rover();
        result.Init(new Point(-1, 2), Direction.N);
        return result;
    }
    [Fact]
    public void AfterInitCurrentPositionAndHeadingShouldMatch()
    {
        var sut = InitialRover();
        sut.CurrentPosition.ShouldBe(new Point(-1, 2));
        sut.CurrentHeading.ShouldBe(Direction.N);
    }
        
    [Fact]
    public void After1Forward_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.F});
            
        sut.CurrentPosition.ShouldBe(new Point(-1, 3));
        sut.CurrentHeading.ShouldBe(Direction.N);
    }
    [Fact]
    public void After1Back_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.B});

        sut.CurrentPosition.ShouldBe(new Point(-1, 1));
        sut.CurrentHeading.ShouldBe(Direction.N);
    }
        
    [Fact]
    public void After1Left_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.L});
            
        sut.CurrentPosition.ShouldBe(new Point(-1, 2));
        sut.CurrentHeading.ShouldBe(Direction.W);
    }
        
    [Fact]
    public void After1Right_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.R});
            
        sut.CurrentPosition.ShouldBe(new Point(-1, 2));
        sut.CurrentHeading.ShouldBe(Direction.E);
    }
        
        
    [Fact]
    public void After1Left1Forward_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.L, Command.F});
            
        sut.CurrentPosition.ShouldBe(new Point(-2, 2));
        sut.CurrentHeading.ShouldBe(Direction.W);
    }
        
    [Fact]
    public void After4Left_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.L, Command.L, Command.L, Command.L});
            
        sut.CurrentPosition.ShouldBe(new Point(-1, 2));
        sut.CurrentHeading.ShouldBe(Direction.N);
    }
    [Fact]
    public void After4Moves_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.F, Command.R, Command.F, Command.R, Command.F, Command.R, Command.F, Command.R});
            
        sut.CurrentPosition.ShouldBe(new Point(-1, 2));
        sut.CurrentHeading.ShouldBe(Direction.N);
    }
        
    [Fact]
    public void AtNorthPoleWrap_After1Forward_PositionAndHeadingShouldBeCorrect()
    {
        var sut = InitialRover();
        sut.Execute(new List<Command> {Command.F, Command.R, Command.F, Command.R, Command.F, Command.R, Command.F, Command.R});
            
        sut.CurrentPosition.ShouldBe(new Point(-1, 2));
        sut.CurrentHeading.ShouldBe(Direction.N);
    }

}