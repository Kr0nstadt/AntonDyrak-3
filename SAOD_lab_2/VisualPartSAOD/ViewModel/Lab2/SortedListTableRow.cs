using DynamicDataStructure;
using System;

namespace VisualPartSAOD.ViewModel.Lab2;

public class SortedListTableRow
{
    public SortedListTableRow()
    {
        _n = 0;
        TheorMC = 0;
        RandomCM = 0;
        IncreaseCM = 0;
        DecreaseCM = 0;
    }
    public SortedListTableRow(int size)
    {
        _n = size;
        int st = 10;
        TheorMC = (int) Math.Pow(2, 9 + (size / 100));

        MyList<int> list = new MyList<int>();
        
        FillList.FillingIncDec(0, 0 - size, list, (e, i) =>
        {
            if (e is MyList<int> myList)
            {
                myList.Add(i);
            }
        });

        DecreaseList = new MyList<int>(list);
        MyList<int>.MergeSort(ref list);
        DecreaseSortedList = new MyList<int>(list);
        DecreaseCM = list.C + list.M;

        list.RemoveAll();

        FillList.FillingIncDec(0, size, list, (e, i) =>
        {
            if (e is MyList<int> myList)
            {
                myList.Add(i);
            }
        });

        IncreaseList = new MyList<int>(list);
        MyList<int>.MergeSort(ref list);
        IncreaseSortedList = new MyList<int>(list);
        IncreaseCM = list.C + list.M;

        list.RemoveAll();

        FillList.FillingRand(list, (e, i) =>
        {
            if (e is MyList<int> myList)
            {
                myList.Add(i);
            }
        }, size, 10, 1000);

        RandomList = new MyList<int>(list);
        MyList<int>.MergeSort(ref list);
        RandomSortedList = new MyList<int>(list);
        RandomCM = list.C + list.M;


    }
    public int N => _n;

    public int TheorMC { get; init; }
    //public int TheorCMHeap {  get; init; }
    public int RandomCM { get; init; }
    public int IncreaseCM { get; init; }
    public int DecreaseCM { get; init; }

    public MyList<int> IncreaseList { get; set; }
    public MyList<int> DecreaseList { get; set; }
    public MyList<int> RandomList { get; set; }
    public MyList<int> IncreaseSortedList { get; set; }
    public MyList<int> DecreaseSortedList { get; set; }
    public MyList<int> RandomSortedList { get; set; }

    private int _n;
}