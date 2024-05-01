namespace DynamicDataStructure;

public static class FillList
{
    public static void FillingIncDec(int start, int end, IEnumerable<int> enumerable,
        Action<IEnumerable<int>, int> addAction)
    {
        if (start > end)
        {
            IEnumerable<int> range = Enumerable.Range(end, start - end + 1).Reverse();
            foreach (int i in range)
            {
                addAction(enumerable, i);
            }
        }
        else
        {
            IEnumerable<int> range = Enumerable.Range(start, end - start + 1);

            foreach (int i in range)
            {
                addAction(enumerable, i);
            }
        }
    }

    public static void FillingRand(IEnumerable<int> enumerable, 
        Action<IEnumerable<int>, int> addAction, int count, 
        int minValue = Int32.MinValue, int maxValue = int.MaxValue)
    {
        Random rnd = new Random();
        for (int i = 0; i < count; ++i)
        {
            addAction(enumerable, rnd.Next(minValue, maxValue));
        }

    }
}