using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital
{
    public class Digital_Sort
    {
        public static int Series(int[] array)
        {
            int res = 1;
            for(int i = 0;i < array.Length-1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    res++;
                }
            }
            return res;
        }
        public static int Series(short[] array)
        {
            int res = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    res++;
                }
            }
            return res;
        }
        public static long Sum(int[] array)
        {
            long res = 0;
            for(int i = 0;i < array.Length; i++)
            {
                res += array[i];
            }
            return res;
        }
        public static long Sum(short[] array)
        {
            long res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                res += array[i];
            }
            return res;
        }
        public static short[] ShortArrayMake(Queue<byte[]> queue)
        {
            short[] result = new short[queue.Count];
            int i = 0;
            while (queue.Count > 0 && i < result.Length)
            {
                result[i]=BitConverter.ToInt16(queue.Dequeue());
                i++;
            }
            return result;
        }
        public static int[] IntArrayMake(Queue<byte[]> queue)
        {
            int[] result = new int[queue.Count];
            int i = 0;
            while (queue.Count > 0 && i < result.Length)
            {
                result[i] = BitConverter.ToInt32(queue.Dequeue());
                i++;
            }
            return result;
        }
        public static string[] StringArrayMake(Queue<byte[]> queue)
        {
            char[] result = new char[queue.Count];
            string[]res = new string[queue.Count];
            int i = 0;
            int y = 0;
            while (queue.Count > 0 && i < result.Length)
            {
                result[i] = BitConverter.ToChar(queue.Dequeue());
                i++;
            }
            for(int l = 0; l < result.Length; l++)
            {
                if (result[l] != ' ')
                {
                    res[y] += result[l];
                }
                else { y++; }
            }
            return res;
        }

        public static Queue<byte[]> QueueMake(int[] array)
        {
            Queue<byte[]> result = new Queue<byte[]>();
            foreach (var item in array)
            {
                result.Enqueue(BitConverter.GetBytes(item));
            }
            return result;
        }
        public static Queue<byte[]> QueueMake(String[] array)
        {
            Queue<byte[]> result = new Queue<byte[]>();
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    result.Enqueue(BitConverter.GetBytes(array[i][j]));
                }
            }
            return result;
        }
        public static Queue<byte[]> QueueMake(short[] array)
        {
            Queue<byte[]> result = new Queue<byte[]>();
            foreach (var item in array)
            {
                result.Enqueue(BitConverter.GetBytes((short)item));
            }
            return result;
        }
        public static Queue<byte[]> DigitalSort(Queue<byte[]> queue, int nByte)
        {
            const int nQueues = 256;
            M = 0;
            Queue<byte[]>[] tempQueues = new Queue<byte[]>[nQueues];
            tempQueues = tempQueues.Select(q => new Queue<byte[]>()).ToArray();
            int maxBytesCount = queue.Max(x => x.Length);
            for (int i = 0; i < maxBytesCount; ++i)
            {
                while (queue.Count > 0)
                {
                    byte[] qItem = queue.Dequeue();
                    M++;
                    tempQueues[qItem[i]].Enqueue(qItem);
                }

                foreach (Queue<byte[]> q in tempQueues)
                {
                    M++;
                    if (q.Count > 0)
                    {
                        while (q.Count > 0)
                        {
                            queue.Enqueue(q.Dequeue());
                        }
                    }
                }
            }

            return queue;
        }

        public static Queue<byte[]> DigitalSortReverse(Queue<byte[]> queue, int nByte)
        {
            const int nQueues = 256;
            M = 0;
            Queue<byte[]>[] tempQueues = new Queue<byte[]>[nQueues];
            tempQueues = tempQueues.Select(q => new Queue<byte[]>()).ToArray();
            int maxBytesCount = queue.Max(x => x.Length);

            for (int i = 0; i < maxBytesCount; ++i)
            {
                while (queue.Count > 0)
                {
                    byte[] qItem = queue.Dequeue();
                    int posByte = qItem.Length - nByte;
                    M++;
                    tempQueues[qItem[i]].Enqueue(qItem);
                }

                for (int j = nQueues - 1; j >= 0; --j)
                {
                    M++;
                    while (tempQueues[j].Count > 0)
                    {
                        queue.Enqueue(tempQueues[j].Dequeue());
                    }
                }
            }

            return queue;
        }
        public static int M;
    }
}
