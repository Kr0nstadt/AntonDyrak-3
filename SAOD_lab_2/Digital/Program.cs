namespace Digital
{
    class MainClass
    {
        static void Main()
        {
            Queue<byte[]> bytes = new Queue<byte[]>();
            bytes.Enqueue(BitConverter.GetBytes((short)10));
            bytes.Enqueue(BitConverter.GetBytes((short)9));
            bytes.Enqueue(BitConverter.GetBytes((short)8));
            bytes.Enqueue(BitConverter.GetBytes((short)7));
            bytes.Enqueue(BitConverter.GetBytes((short)6));
            bytes.Enqueue(BitConverter.GetBytes((short)5));
            bytes.Enqueue(BitConverter.GetBytes((short)4));
            bytes.Enqueue(BitConverter.GetBytes((short)3));
            bytes.Enqueue(BitConverter.GetBytes((short)2));




            /*
            IntArrayMade IntArray = new IntArrayMade(20);
            Queue<byte[]> res = Digital_Sort.DigitalSort(Digital_Sort.QueueMake(IntArray.DecIntArray), (Digital_Sort.QueueMake(IntArray.DecIntArray).Peek().Length));
            int[] result = Digital_Sort.IntArrayMake(res);
            foreach (byte[] array in res)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write((int)array[i]);
                }
                Console.WriteLine();
            }
            */
            Console.WriteLine(Convert.ToString(BitConverter.ToInt16(BitConverter.GetBytes((short)5678)), 2).PadLeft(16, '0'));

        }
    }
}