using System.Globalization;

namespace ShapeLibrary.Shapes;

public class Circle : IShape
{
    public Circle(Point center, double radius)
    {
        _center = center;
        _radius = radius;
    }

    public override string ToString()
    {
        return $"circle({_center}, " +
               $"{_radius.ToString(new NumberFormatInfo{CurrencyDecimalSeparator = "."})})";
    }

    //интерфейсик
    public bool IsIntesection(IShape shape)
    {
        if (shape is Circle circle)
        {
            double xSub = _center.X - circle.Center.X;
            double xSqr = xSub * xSub;

            double ySub = _center.Y - circle.Center.Y;
            double ySqr = ySub * ySub;

            double len = Math.Sqrt(xSqr + ySqr);

            return len <= Radius + circle.Radius;
        }

        return false;
    }

    public Point Center => _center;
    public double Radius => _radius;

    

    private Point _center;
    private double _radius;

    public double _s()
    {
        return Math.PI * (_radius * _radius);
    }

    public double _p()
    {
        return Math.PI * _radius * 2;
    }
}