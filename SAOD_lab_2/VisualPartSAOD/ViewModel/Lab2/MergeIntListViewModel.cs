using DynamicDataStructure;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2;

public class MergeIntListViewModel
{
    public MergeIntListViewModel(MyList<int> list, MyList<int> sortedList, Complexity m, Complexity c)
    {
        _intList = list;
        _sortedIntList = sortedList;
        _c = c;
        _m = m;
    }

    public override string ToString()
    {
        int n = _intList.Count;


        return $"Исходный массив: {_intList}\n\n" +
               $"Количество серий до сортировки: {_intList.GetIncreaseSeries()}\n" +
               $"Контрольная сумма до сортировки: {_intList.GetCheckSum()}\n\n" +
               $"Массив после сортировки: {_sortedIntList}\n\n" +
               $"Количество серий после сортировки: {_sortedIntList.GetIncreaseSeries()}\n" +
               $"Контрольная сумма после сортировки: {_sortedIntList.GetCheckSum()}\n\n" +
               $"Фактические пересылки: {_sortedIntList.M}\n" +
               $"Фактические сравнения: {_sortedIntList.C}\n\n";
    }

    private MyList<int> _intList;
    private MyList<int> _sortedIntList;
    private Complexity _m;
    private Complexity _c;
}