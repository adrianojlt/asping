namespace Sharping.Solid.OpenClosed.Shapes
{
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public readonly ShapeType Type = ShapeType.Triangle;

        public double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }
}
