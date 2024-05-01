using ShapeLibrary.Shapes;

namespace ShapeLibrary.Parsers.BaseParsers;

public interface IShapeParser
{
    IShape Parse(string shapeStringRepresentation);
}
//интерфейс что б делить строку на точки и тд