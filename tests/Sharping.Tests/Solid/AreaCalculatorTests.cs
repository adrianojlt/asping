using Sharping.Solid.OpenClosed.Shapes;

namespace Sharping.Tests.Solid;

public class AreaCalculatorTests
{

    [Fact]
    public void Solid_OpenClosed_CalculateShapes() 
    {
        var Shapes = new IShape[] 
        { 
            new Rectangle { Width = 5, Height = 10 },
            new Circle { Radius = 7 }
        };

        var areaCalc = new AreaCalculator();

        var result = areaCalc.CalculateTotalArea( Shapes );

        Assert.InRange(result, 203.9, 204);
    }

}
