using System.Text;
using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.Contexts;

namespace ShapeLibrary.Parsers.States.BaseStates;

public abstract class NumberState : BaseState
{
    protected override void CheckMatching(IContext context)//смотрит,что б точки на своих местах были в дабле, иначе генерит ошибку
    {
        ParseNumber(context);

        if (context.ShapeStringRepresentation[context.Position] == '.')
        {
            _sb.Append('.');
            ++context.Position;
            ParseNumber(context);

            if (_sb[_sb.Length - 1] == '.')
            {
                throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "`digit`");
            }
        }
    }

    public string NumberStringRepresentation => _sb.ToString();

    protected abstract override void ChangeState(IContext context);

    private void ParseNumber(IContext context)//на случай ошибки при разделении
    {
        if (context.Position >= context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "`digit` or \'.\'");
        }

        while (Char.IsDigit(context.ShapeStringRepresentation[context.Position]))
        {
            _sb.Append(context.ShapeStringRepresentation[context.Position]);
            ++context.Position;
            if (context.Position >= context.ShapeStringRepresentation.Length)
            {
                throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "`digit` or \'.\'");
            }
        }
    }

    private StringBuilder _sb = new StringBuilder();
}