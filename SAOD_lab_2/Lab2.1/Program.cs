// See https://aka.ms/new-console-template for more information
using DynamicDataStructure;

Console.WriteLine("#### Функции для создания стека ####\n");
Console.WriteLine("1)Заполнение стека возрастающими числами :");
MyStack<int> stack = new MyStack<int>();
FillList.FillingIncDec(40, 1, stack, (e, i) =>
{
    if (e is MyStack<int> stack)
    {
        stack.Push(i);
    }
});

Console.WriteLine("   " + stack);

MyList<int> lists = new MyList<int>();
FillList.FillingIncDec(1, 40, lists, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});
Console.WriteLine($"Контрольная сумма : {lists.GetCheckSum()}");
Console.WriteLine($"Количество серий : {lists.GetIncreaseSeries()} \n");
lists.RemoveAll();
Console.WriteLine("2)Заполнение стека убывающими числами :");
stack = new MyStack<int>();

FillList.FillingIncDec(1, 40, stack, (e, i) =>
{
    if (e is MyStack<int> stack)
    {
        stack.Push(i);
    }
});

Console.WriteLine("   " + stack);
FillList.FillingIncDec(40, 1, lists, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});
Console.WriteLine($"Контрольная сумма : {lists.GetCheckSum()}");
Console.WriteLine($"Количество серий : {lists.GetIncreaseSeries()}\n");
lists.RemoveAll();
Console.WriteLine("3)Заполнение стека случайными числами :");
stack = new MyStack<int>();

FillList.FillingRand(stack, (e, i) =>
{
    if (e is MyStack<int> stack)
    {
        stack.Push(i);
    }
}, 40, 10, 99);

Console.WriteLine("   " + stack);
lists.RemoveAll();
FillList.FillingRand(lists, (e, i) =>
{
    if (e is MyList<int> stack)
    {
        stack.Add(i);
    }
}, 40, 10, 99);

//Console.WriteLine(lists);
Console.WriteLine($"Контрольная сумма : {lists.GetCheckSum()}");
Console.WriteLine($"Количество серий : {lists.GetIncreaseSeries()}\n");


Console.WriteLine("\n\n#### Функции для создания очереди ####\n");
Console.WriteLine("1)Заполнение очереди возрастающими числами :");
MyQueue<int> queue = new MyQueue<int>();

FillList.FillingIncDec(1, 40, queue, (e, i) =>
{
    if (e is MyQueue<int> queue)
    {
        queue.Enqueue(i);
    }
});

Console.WriteLine("   " + queue);
lists.RemoveAll();
FillList.FillingIncDec(1, 40, lists, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});
Console.WriteLine($"Контрольная сумма : {lists.GetCheckSum()}");
Console.WriteLine($"Количество серий : {lists.GetIncreaseSeries()} \n");
lists.RemoveAll();
Console.WriteLine("2)Заполнение очереди убывающими числами :");
queue = new MyQueue<int>();

FillList.FillingIncDec(40, 1, queue, (e, i) =>
{
    if (e is MyQueue<int> queue)
    {
        queue.Enqueue(i);
    }
});
Console.WriteLine("   " + queue);
FillList.FillingIncDec(40, 1, lists, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});
Console.WriteLine($"Контрольная сумма : {lists.GetCheckSum()}");
Console.WriteLine($"Количество серий : {lists.GetIncreaseSeries()} \n");
Console.WriteLine("3)Заполнение очереди случайными числами :");
queue = new MyQueue<int>();

FillList.FillingRand(queue, (e, i) =>
{
    if (e is MyQueue<int> queue)
    {
        queue.Enqueue(i);
    }
}, 40, 10, 99);

Console.WriteLine("   " + queue);
lists.RemoveAll();\
FillList.FillingRand(lists, (e, i) =>
{
    if (e is MyList<int> stack)
    {
        stack.Add(i);
    }
}, 40, 10, 99);

//Console.WriteLine(lists);
Console.WriteLine($"Контрольная сумма : {lists.GetCheckSum()}");
Console.WriteLine($"Количество серий : {lists.GetIncreaseSeries()}\n");


Console.WriteLine("\n\n#### Функции для работы со списком ####\n");
Console.WriteLine("Печать элементов списка, подсчет контрольной суммы, подсчет количества серий \n");
MyList<int> list = new MyList<int>();
FillList.FillingRand(list, (e, i) =>
{
    if (e is MyList<int> stack)
    {
        stack.Add(i);
    }
}, 40, 10, 99);

Console.WriteLine(list);
Console.WriteLine($"Контрольная сумма : {list.GetCheckSum()}");
Console.WriteLine($"Количество серий : {list.GetIncreaseSeries()}");
Console.WriteLine($"Количество элементов : {list.Count}\n");

list.RemoveAll();

FillList.FillingIncDec(39, 0, list, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});

Console.WriteLine(list);
Console.WriteLine($"Контрольная сумма : {list.GetCheckSum()}");
Console.WriteLine($"Количество серий : {list.GetIncreaseSeries()}");
Console.WriteLine($"Количество элементов : {list.Count}\n");

list.RemoveAll();

FillList.FillingIncDec(0, 39, list, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});

Console.WriteLine(list);
Console.WriteLine($"Контрольная сумма : {list.GetCheckSum()}");
Console.WriteLine($"Количество серий : {list.GetIncreaseSeries()}");
Console.WriteLine($"Количество элементов : {list.Count}\n");

Console.WriteLine("Функция удаления всех элементов и рекурсивной печати");
list.RemoveAll();
FillList.FillingRand(list, (e, i) =>
{
    if (e is MyList<int> stack)
    {
        stack.Add(i);
    }
}, 10, 10, 99);
Console.WriteLine("Исходный : " + list);
Console.WriteLine("Прямой : " + list.ToStringForward());
Console.WriteLine("Обратный : " + list.ToStringBackward());

