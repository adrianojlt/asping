namespace Sharping.Solid.OpenClosed.Shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public readonly ShapeType Type = ShapeType.Circle;

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
