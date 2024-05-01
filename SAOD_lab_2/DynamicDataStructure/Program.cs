// See https://aka.ms/new-console-template for more information
using DynamicDataStructure;

//Queue
Console.WriteLine("Queue:");
MyQueue<int> queue = new MyQueue<int>();

FillList.FillingIncDec(10, 20, queue, (e, i) =>
{
    if (e is MyQueue<int> queue)
    {
        queue.Enqueue(i);
    }
});

Console.WriteLine(queue);

queue = new MyQueue<int>();

FillList.FillingIncDec(20, 10, queue, (e, i) =>
{
    if (e is MyQueue<int> queue)
    {
        queue.Enqueue(i);
    }
});

Console.WriteLine(queue);

queue = new MyQueue<int>();

FillList.FillingRand(queue,(e, i) =>
{
    if (e is MyQueue<int> queue)
    {
        queue.Enqueue(i);
    }
}, 10, 10, 20);

Console.WriteLine(queue);


//Stack
Console.WriteLine();
Console.WriteLine("Stack:");
MyStack<int> stack = new MyStack<int>();
FillList.FillingIncDec(10, 20, stack, (e, i) =>
{
    if (e is MyStack<int> stack)
    {
        stack.Push(i);
    }
});

Console.WriteLine(stack);

stack = new MyStack<int>();

FillList.FillingIncDec(20, 10, stack, (e, i) =>
{
    if (e is MyStack<int> stack)
    {
        stack.Push(i);
    }
});

Console.WriteLine(stack);

stack = new MyStack<int>();

FillList.FillingRand(stack, (e, i) =>
{
    if (e is MyStack<int> stack)
    {
        stack.Push(i);
    }
}, 10, 10, 20);

Console.WriteLine(stack);

//List

Console.WriteLine();
Console.WriteLine("List:");
MyList<int> list = new MyList<int>();
FillList.FillingIncDec(10, 20, list, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});

Console.WriteLine(list);
Console.WriteLine($"CheckSum: {list.GetCheckSum()}");
Console.WriteLine($"Series: {list.GetIncreaseSeries()}");
Console.WriteLine($"Count: {list.Count}");

list.RemoveAll();

FillList.FillingIncDec(20, 10, list, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
});

Console.WriteLine(list);
Console.WriteLine($"CheckSum: {list.GetCheckSum()}");
Console.WriteLine($"Series: {list.GetIncreaseSeries()}");
Console.WriteLine($"Count: {list.Count}");

list.RemoveAll();

FillList.FillingRand(list, (e, i) =>
{
    if (e is MyList<int> list)
    {
        list.Add(i);
    }
}, 20, 10, 20);

Console.WriteLine(list);
Console.WriteLine($"CheckSum: {list.GetCheckSum()}");
Console.WriteLine($"Series: {list.GetIncreaseSeries()}");
Console.WriteLine($"Count: {list.Count}");

MyList<int>.MergeSort(ref list);
Console.WriteLine(list);


