using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleEndState : BaseState
{
    //низя ничего после скобок писать,фу таким быть
    protected override void CheckMatching(IContext context)
    {
        if (context.Position < context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "End of string");
        }
    }

    //правильно, нафиг переопределения, туда его 
    protected override void ChangeState(IContext context)
    {
        
    }
}