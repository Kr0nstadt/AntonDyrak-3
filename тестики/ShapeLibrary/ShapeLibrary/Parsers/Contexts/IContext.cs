using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.Contexts;

public interface IContext
{
    public string ShapeStringRepresentation { get; }
    public IState State { get; set; }
    int Position { get; set; }
}
// позиция что б по тексту ползать, это счетчик в CircleStartWordState видно
// еще состояние и строка литая