using System.Globalization;
using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;
using ShapeLibrary.Parsers.States.CircleStates;
using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Parsers.ShapeParsers;

public class CircleParser : IShapeParser
{
    public IShape Parse(string shapeStringRepresentation)
    {
        //так узнаем где кончаются буковки
        IState state = new CircleStartWordState();

        //так получаем только цифорки
        CircleContext context = new CircleContext(shapeStringRepresentation, state);

        do
        {
            state.Processing(context);
            state = context.State;
        } while (state is not CircleEndState);

        state.Processing(context);//проверяет косячки все

        //делит цифорки по полям
        double centerX = double.Parse(context.CenterXStringRepresentation,
            new NumberFormatInfo { NumberDecimalSeparator = "." });

        double centerY = double.Parse(context.CenterYStringRepresentation,
            new NumberFormatInfo { NumberDecimalSeparator = "." });

        double radius = double.Parse(context.RadiusStringRepresentation,
            new NumberFormatInfo { NumberDecimalSeparator = "." });

        //создает круг из точки и ридиуса
        return new Circle(new Point(centerX, centerY), radius);
    }
}