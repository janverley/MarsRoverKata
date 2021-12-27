using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace MarsRoverKata.Tests;

public class MathTests
{
    private readonly ITestOutputHelper testOutputHelper;

    public MathTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void PointDiff_ShouldBeOk()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(90, 0);
        var p3 = new Point(0, 90);
        var p4 = new Point(45, 45);

        testOutputHelper.WriteLine(p1.ToString());
        testOutputHelper.WriteLine(p2.ToString());
        testOutputHelper.WriteLine(p3.ToString());
        
        p1.Diff(p2).Latitude.ShouldBe(90);
        p1.Diff(p2).Longitude.ShouldBe(0);
        p2.Diff(p3).Latitude.ShouldBe(90);
        p2.Diff(p3).Longitude.ShouldBe(90);
        p1.Diff(p4).Latitude.ShouldBe(45);
        p1.Diff(p4).Longitude.ShouldBe(45);
        p2.Diff(p4).Latitude.ShouldBe(45);
        p2.Diff(p4).Longitude.ShouldBe(45);
        p3.Diff(p4).Latitude.ShouldBe(45);
        p3.Diff(p4).Longitude.ShouldBe(45);
    }
    [Fact]
    public void ArcLength_ShouldBeOk()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(90, 0);
        var p3 = new Point(0, 90);
        var p4 = new Point(45, 0);

        testOutputHelper.WriteLine(p1.ToString());
        testOutputHelper.WriteLine(p2.ToString());
        testOutputHelper.WriteLine(p3.ToString());
        testOutputHelper.WriteLine(p4.ToString());
        
        p1.ArcLength().ShouldBe(0);
        p2.ArcLength().ShouldBe(Mars.Radius * Math.Tau / 4);
        p3.ArcLength().ShouldBe(Mars.Radius * Math.Tau / 4);
        p4.ArcLength().ShouldBe(Mars.Radius * Math.Tau / 8);
    }}