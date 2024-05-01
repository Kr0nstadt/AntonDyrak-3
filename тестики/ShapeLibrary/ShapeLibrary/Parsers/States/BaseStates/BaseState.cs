using ShapeLibrary.Parsers.Contexts;

namespace ShapeLibrary.Parsers.States.BaseStates;

public abstract class BaseState : IState
{
    public virtual void Processing(IContext context)//пускает объект на проверку
    {
        SkipWhiteSpace(context);//нафиг пробелы
        CheckMatching(context);//смотрит что б все стояло там где надо
        SkipWhiteSpace(context);//нафиг пробелы
        ChangeState(context);//меняет состояние объектов, косячные или нет
    }

    protected abstract void CheckMatching(IContext context);
    protected abstract void ChangeState(IContext context);

    protected virtual void SkipWhiteSpace(IContext context)
    {
        while (context.Position < context.ShapeStringRepresentation.Length && 
               context.ShapeStringRepresentation[context.Position] == ' ')
        {
            ++context.Position;
        }
    }
}