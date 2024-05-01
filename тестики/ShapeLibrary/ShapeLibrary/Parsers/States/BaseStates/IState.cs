using ShapeLibrary.Parsers.Contexts;

namespace ShapeLibrary.Parsers.States.BaseStates;

public interface IState
{
    void Processing(IContext context);
    //метод для проверки всех косяков
}