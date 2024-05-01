namespace ShapeLibrary.Shapes;

public interface IShape
{
    bool IsIntesection(IShape circle);
    double _s();
    double _p();
    double S => _s();
    double P => _p();
}