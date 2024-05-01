using System.Text;
using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Parsers.ShapeParsers;
using ShapeLibrary.Shapes;

//читалка файла
StreamReader sr;

switch (args.Length)
{
    //from stdin
    case 0:
        sr = new StreamReader(Console.OpenStandardInput());
        break;

    //from file
    case 1:
        try
        {
            sr = new StreamReader(args[0]);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File not found: {ex.FileName}");
            return;
        }

        break;

    default:
        return;
}


//список для фигур
List<IShape> shapes = new List<IShape>();

//чтение в консоли
string? circleStringRepresentation = sr.ReadLine();

//пока строка на входе не пустая, суем в список
while (string.IsNullOrEmpty(circleStringRepresentation) == false &&
       string.IsNullOrWhiteSpace(circleStringRepresentation) == false)
{
    //создание разделялки и объявление фигуры
    IShapeParser parser = new CircleParser();
    IShape shape;

    try
    {
        //пытаемся запихать в фигуру разделенную строку
        shape = parser.Parse(circleStringRepresentation);
    }
    catch (InvalidCharacterExeption ex)
    {
        //ошибка если косяк
        PrintError(ex);
        return;
    }

    shapes.Add(shape);

    circleStringRepresentation = sr.ReadLine();
}

//вывод фигуры, ее данных и пересечений
foreach(IShape shape in shapes)
{
    Console.WriteLine($"{shape.ToString()}\n" +
        $"P : {shape.P}" +
        $"\nS : {shape.S}");
    PrintIntersect(shape, shapes);
    Console.WriteLine();
}

void PrintError(InvalidCharacterExeption ex)
{
    Console.WriteLine($"Invalid character at {ex.Position} expected {ex.Expected}:");
    Console.WriteLine(ex.StringRepresentation);

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < ex.Position; i++)
    {
        sb.Append('-');
    }

    sb.Append('^');

    Console.WriteLine(sb.ToString());
}

void PrintIntersect(IShape shape, List<IShape> shapes)
{
    List<IShape> intersectsShapes = shapes.Where(s => s.IsIntesection(shape)).ToList();
    if (intersectsShapes.Count > 0)
    {
        Console.WriteLine("Intersection:");
    }
    else
    {
        Console.WriteLine("Intersection: None");
    }

    foreach (IShape intersectsShape in intersectsShapes)
    {
        Console.WriteLine($"   {intersectsShape.ToString()}");
    }
}
