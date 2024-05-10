using Hash;

/*RandomIntArray randomInt = new RandomIntArray(50);
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
Console.WriteLine(hash.SearchResIndex);*/

RandomIntArray randomIntArray = new RandomIntArray(20);
for(int i = 0; i < 20; i++)
{
    Console.Write(randomIntArray.Data[i] + " ");
}
Console.WriteLine();
HashTwoIntArray hashTwoIntArrayOne = new HashTwoIntArray(randomIntArray, 20, 1);
Console.WriteLine(hashTwoIntArrayOne);
Console.WriteLine(hashTwoIntArrayOne.Cal);
Console.WriteLine("\n\n");
HashTwoIntArray hashTwoIntArrayTwo = new HashTwoIntArray(randomIntArray, 20, 2);
Console.WriteLine(hashTwoIntArrayTwo);
Console.WriteLine(hashTwoIntArrayTwo.Cal);