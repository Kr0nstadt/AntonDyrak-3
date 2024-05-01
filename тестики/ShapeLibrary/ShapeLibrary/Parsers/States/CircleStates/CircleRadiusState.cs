using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleRadiusState : NumberState
{
    protected override void ChangeState(IContext context)
    {
        if (context is CircleContext circleContext)
        {
            circleContext.RadiusStringRepresentation = NumberStringRepresentation;
        }

        context.State = new CircleCloseBracketState();
    }
    //короче, во всех оверайдах есть переход к следующей проверке. это последняя и просто смотрит что радиус это радиус
}