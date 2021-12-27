using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class AtEquator
    {
        private Rover InitialRover()
        {
            var result = new Rover();
            result.Init(new Point(Mars.EquatorLength, 0), Direction.E);
            return result;
        }

        [Fact]
        public void AfterInitCurrentPositionAndHeadingShouldMatch()
        {
            var sut = InitialRover();
            sut.CurrentPosition.ShouldBe(new Point(Mars.EquatorLength, 0));
            sut.CurrentHeading.ShouldBe(Direction.E);
        }

        [Fact]
        public void ShouldWrap()
        {
            var sut = InitialRover();

            sut.Execute(new List<Command> { Command.F });

            sut.CurrentPosition.ShouldBe(new Point(1, 0));
            sut.CurrentHeading.ShouldBe(Direction.E);
        }
    }
}