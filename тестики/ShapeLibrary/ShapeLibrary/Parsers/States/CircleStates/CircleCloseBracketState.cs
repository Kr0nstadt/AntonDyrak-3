using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleCloseBracketState : BaseState
{
    //Смотрит что б все скобки были закрыты
    protected override void CheckMatching(IContext context)
    {
        if (context.Position >= context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\')\'");
        }

        if (context.ShapeStringRepresentation[context.Position] != ')')
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\')\'");
        }

        ++context.Position;
    }

    //в принципе нафиг не надо тут переопределять, но надо
    protected override void ChangeState(IContext context)
    {
        context.State = new CircleEndState();
    }
}