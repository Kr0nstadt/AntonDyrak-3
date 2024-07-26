using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.DigitalSort
{
    internal static class DigitalSort
    {
        public static void Sort(IList<IByteGetter> list)
        {
            Queue<IByteGetter> queue = new Queue<IByteGetter>(list);
            const int nQueues = 256;
            Queue<IByteGetter>[] tempQueues = new Queue<IByteGetter>[nQueues];//тут точно 256?
            tempQueues = tempQueues.Select(q => new Queue<IByteGetter>()).ToArray();
            int maxBytesCount = queue.Max(x => x.CountByte);
            for (int i = 0; i < maxBytesCount; ++i)
            {
                while (queue.Count > 0)
                {
                    IByteGetter qItem = queue.Dequeue();
                    tempQueues[qItem.GetByte(i)].Enqueue(qItem);
                }

                foreach (Queue<IByteGetter> q in tempQueues)
                {
                    while (q.Count > 0)
                    {
                        queue.Enqueue(q.Dequeue());
                    }
                }
            }

            list.Clear();
            
            foreach(IByteGetter byteGetter in queue)
            {
                list.Add(byteGetter);
                //Console.WriteLine(byteGetter.ToString());
            }
        }
    }
}
