using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleStartWordState : BaseState
{
    protected override void CheckMatching(IContext context)
    {
        string circleWord = "circle";

        foreach (char c in circleWord)
        {
            if (context.Position >= context.ShapeStringRepresentation.Length)
            {
                throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\'circle\'");
            }

            if (context.ShapeStringRepresentation[context.Position]
                    .ToString()
                    .ToLower()
                    .Equals(c.ToString()) == false)
            {
                throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\'circle\'");
            }

            ++context.Position;
        }
    }
    //проверяет косяки в написании названии фигуры.Если косяк, то создает исключения. ползает по позициям
    //возвращает позицию где кончаются буковки

    protected override void ChangeState(IContext context)
    {
        context.State = new CircleOpenBracketState();
    }
}