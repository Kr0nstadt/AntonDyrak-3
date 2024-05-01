using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleOpenBracketState : BaseState
{
    //тоже смотрит что б скобки были закрыты. только в другую сторону
    protected override void CheckMatching(IContext context)
    {
        if (context.Position >= context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\'(\'");
        }

        if (context.ShapeStringRepresentation[context.Position] != '(')
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\'(\'");
        }

        ++context.Position;
    }

    protected override void ChangeState(IContext context)
    {
        context.State = new CircleCenterXState();
    }
}