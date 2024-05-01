using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class HeapCreator : BaseSortedIntArray
    {
        public HeapCreator() : base() { }
        public HeapCreator(BaseIntArray baseIntArray) : base(baseIntArray) { }
        
        public override int TC => (int)(2 * i * Math.Log2(i) + i + 2);
        public override int TM => (int)(i * Math.Log2(i) + 6 * i + 4);
        protected override void Sort()
        {
            int L, R;
            int n = Data.Length;
            M++;
            L = (int)((n - 1) / 2);
            while(L >= 0)
            {
                C++;
                C++;
                BildHeap(Data, L, n - 1);
                L--;
            }
            R = n - 1;
            while (R > 0)
            {
                int temp = Data[0];
                Data[0] = Data[R];
                Data[R] = temp;
                M += 3;
                //C++;
                R--;
                BildHeap(Data, 0, R);
            }
            M++;
        }
        public void BildHeap(int[] Data, int L, int R)
        {
            M++;
            int x = Data[L];
            int i = L;
            while (true)
            {
                int j = 2 * i;
                if(j > R)
                {
                    C++;
                    break;

                    
                }
                
                if ((j < R) && (Data[j + 1] <= Data[j]))
                {
                    j += 1;
                    C+=2;
                }
                
                if (x <= Data[j])
                {
                    //C++;
                    break;
                   
                }
                
                Data[i] = Data[j];
                i = j;
                M++;
                Data[i] = x;
                M++;
            }
        }
       
    }
}
