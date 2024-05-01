namespace ShapeLibrary.Exeptions;

public class InvalidCharacterExeption : Exception
{
    public InvalidCharacterExeption(string stringRepresentation, int position, string expected) : base()
    {
        _stringRepresentation = stringRepresentation;
        _position = position;
        _expected = expected;
    }

    public string StringRepresentation => _stringRepresentation;
    public int Position => _position;
    public string Expected => _expected;

    private string _stringRepresentation;
    private int _position;
    private string _expected;
}
//конструктор для отображения ошибок. на вход строка неделенная,
//индекс из массива чаров,что б оно галочкой показывалось, текст ошибки
//наследуется от внутренних ошибок
//свойства что б юзать поля
//поля что б были поля