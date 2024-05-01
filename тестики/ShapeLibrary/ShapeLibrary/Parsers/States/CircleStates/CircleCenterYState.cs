using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleCenterYState : NumberState
{
    protected override void ChangeState(IContext context)
    {
        if (context is CircleContext circleContext)
        {
            circleContext.CenterYStringRepresentation = NumberStringRepresentation;
        }

        context.State = new CircleCommaState();
    }
}
//меняет состояние у У центра круга 