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

    public void DrawShape(ShapeType type, object options) 
    {

        switch (type) 
        { 
            case ShapeType.Circle:
                // do Circle logic
                break;
            case ShapeType.Triangle: 
                // do Triangle logic
                break;
        }

    }

    public void DoStuffWithShape(ShapeType type, object options) 
    { 

    }
}
