using _9._1;
using CustomList;
using System;
class MainClass
{
    static void Main()
    {
        CustomList<Stydent> list = new CustomList<Stydent>();
        Random rnd = new Random();
        list.Add(new Stydent("Сидоров",rnd.Next(2,5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Петров", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Иванов", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Солодов", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Степаненко", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Андропов", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Кешка", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Пешков", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Разуваева", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Сафронова", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        list.Add(new Stydent("Литвиненко", rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5)));
        Console.WriteLine(list);
        Console.WriteLine();
        list.Sort();
        Console.WriteLine(list);

    }
}