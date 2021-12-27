using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class AtNorthPole
    {
        private Rover InitialRover()
        {
            var result = new Rover();
            result.Init(new Point(0, Mars.NorthPoleToEquatorDistance), Direction.N);
            return result;
        }
        
        [Fact]
        public void AfterInitCurrentPositionAndHeadingShouldMatch()
        {
            var sut = InitialRover();
            sut.CurrentPosition.ShouldBe(new Point(0,Mars.NorthPoleToEquatorDistance));
            sut.CurrentHeading.ShouldBe(Direction.N);
        }

        [Fact]
        public void ShouldWrap()
        {
            var sut = InitialRover();
            
            sut.Execute(new List<Command> {Command.F});

            sut.CurrentPosition.ShouldBe(new Point(5,Mars.NorthPoleToEquatorDistance - 1));
            sut.CurrentHeading.ShouldBe(Direction.S);
        }
    }
}