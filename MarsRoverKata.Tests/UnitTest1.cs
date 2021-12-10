using Shouldly;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new Rover();

            sut.Init(new Point(0, 0), Direction.N);

            sut.StartingPoint.ShouldBe(new Point(0, 0));
        }
    }
}