using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public abstract class BaseSortedIntArray : BaseIntArray
    {
        public BaseSortedIntArray()
        {
            _m = 0;
            _c = 0;
        }
        public BaseSortedIntArray(BaseIntArray array) : base((uint)array.Length)
        {
            _m = 0;
            _c = 0;
            array.Data.CopyTo(Data, 0);
            Sort();
        }

        public int M
        {
            get => _m;
            protected set { _m = value; }
        }
        public int C
        {
            get => _c;
            protected set { _c = value; }
        }
        public int PM
        {
            get => _pm;
            protected set { _pm = value; }
        }
        public int PC
        {
            get => _pc;
            protected set { _pc = value; }
        }
        public int CMHeap
        {
            get => _cmHeap;
            protected set { _cmHeap = value; }
        }
        public string Gep
        {
            get => _gep;

            protected set
            {
                _gep =  value + " ";
            }
        }
        public int Step
        {
            get => _step;
            protected set { _step = value; }
        }
        public abstract int TM { get; }
        public abstract int TC { get; }
        public int TPM => (int)(Math.Log2((i) / (i/2)));
        public int TPC => (int)(Math.Log2((i) / (i/2) * 2));
        public int TCMHeap =>(int)(Math.Log2((Data.Length - 1)/1)+2)+2*(int)Math.Log2((Data.Length - 1)/1)*i;
        public int CMHeapSort => (int)(2 * i * Math.Log2(i) + i + 2 + i * Math.Log2(i) + 6.5 * i + 4);
        public int i => (Data.Length);
        protected abstract void Sort();

        private int _m;
        private int _c;
        private int _pm;
        private int _pc;
        private string _gep;
        private int _step;
        private int _cmHeap;
    }
}
