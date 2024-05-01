using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleCenterXState : NumberState
{
    protected override void ChangeState(IContext context)
    {
        if (context is CircleContext circleContext)
        {
            circleContext.CenterXStringRepresentation = NumberStringRepresentation;
        }

        context.State = new CircleCenterYState();
    }
}
//меняет состояние у контекста точки Х центра круга