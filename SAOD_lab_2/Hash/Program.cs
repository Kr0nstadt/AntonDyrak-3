using Hash;

RandomIntArray randomInt = new RandomIntArray(50);
randomInt.Data[0] = 12;
randomInt.Data[7] = 12;
randomInt.Data[8] = 12;
randomInt.Data[3] = 12;
for (int i = 0; i < 50; i++)
{
    Console.Write(randomInt.Data[i] + " ");
}
Console.WriteLine();
BaseHashIntArray hash = new BaseHashIntArray(randomInt,5,12);
Console.WriteLine(hash.ToString());
Console.WriteLine(hash.Cal);
Console.WriteLine(hash.SearchRes);
Console.WriteLine(hash.SearchResIndex);