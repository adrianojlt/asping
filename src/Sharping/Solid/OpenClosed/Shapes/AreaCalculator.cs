namespace Sharping.Solid.OpenClosed.Shapes;

public class AreaCalculator
{
    public double CalculateTotalArea(IShape[] shapes)
    {
        double totalArea = 0;

        foreach (var shape in shapes)
        {
            totalArea += shape.CalculateArea();
        }

        return totalArea;
    }
}
