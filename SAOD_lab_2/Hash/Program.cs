using Hash;

RandomIntArray randomInt = new RandomIntArray(50);
for(int i = 0; i < 50; i++)
{
    Console.Write(randomInt.Data[i] + " ");
}
Console.WriteLine();
BaseHashIntArray hash = new BaseHashIntArray(randomInt,5);
Console.WriteLine(hash.ToString());