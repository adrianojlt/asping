namespace Sharping.Solid.OpenClosed.Shapes;

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public readonly ShapeType Type = ShapeType.Rectangle;

    public double CalculateArea()
    {
        return Width * Height;
    }
}
