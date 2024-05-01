using SAOD_lab_2;

class MyClass
{
    static void Main()
    {
        RandomIntArray randomIntArray = new RandomIntArray(20);
        QuickSortFirst quickSortFirst = new QuickSortFirst(randomIntArray);
        foreach(int i in randomIntArray.Data)
        {
            Console.Write(i+ " ");
        }
        //quickSortFirst.leftIndex = 0;
        Console.WriteLine();
        //quickSortFirst.rightIndex = randomIntArray.Length-1;
        
        foreach (int i in quickSortFirst.Data)
        {
            Console.Write(i+" ");
        }
        
    }
}