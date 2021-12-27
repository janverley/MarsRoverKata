using System;
using System.Collections.Generic;
using System.Globalization;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace MarsRoverKata.Tests
{
    public class AtEquatorGeographicCoordinates
    {
        private readonly ITestOutputHelper testOutputHelper;

        public AtEquatorGeographicCoordinates(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        private Rover InitialRover()
        {
            var result = new Rover();
            result.Init(Point.Origin, Direction.E);
            return result;
        }

        [Fact]
        public void AfterInitCurrentPositionAndHeadingShouldMatch()
        {
            var sut = InitialRover();
            sut.CurrentPosition.ShouldBe(Point.Origin);
            sut.CurrentHeading.ShouldBe(Direction.E);
        }

        [Fact]
        public void ShouldBeOk()
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
            testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.Origin).ToString(CultureInfo.InvariantCulture));

            sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBe(2662107.1, 1);
            sut.CurrentPosition.Latitude.UnWrap().ShouldBe(0, 1);
            sut.CurrentPosition.Longitude.UnWrap().ShouldBe(45, 1);

            sut.CurrentHeading.ShouldBe(Direction.E);
        }
        [Fact]
        public void ShouldBeWrap()
        {
            var sut = InitialRover();

            var commands = new List<Command>();

            var dist = Mars.Radius * Math.Tau *1.125;
            for (int i = 0; i < dist; i++)
            {
                commands.Add(Command.F);
            }
            sut.Execute(commands);

            testOutputHelper.WriteLine(sut.ToString());
            testOutputHelper.WriteLine(sut.CurrentPosition.ArcLength(Point.Origin).ToString(CultureInfo.InvariantCulture));

            sut.CurrentPosition.Diff(Point.Origin).ArcLength().ShouldBe(2662107.1, 1);
            sut.CurrentPosition.Latitude.UnWrap().ShouldBe(0, 1);
            sut.CurrentPosition.Longitude.UnWrap().ShouldBe(45, 1);

            sut.CurrentHeading.ShouldBe(Direction.E);
        }
    }
}