using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public abstract class BaseSearchIntArray : BaseIntArray
    {
        public BaseSearchIntArray()
        {
            _m = 0;
            _c = 0;
            this.x = 0;
            _searchRes = 0;
            _searchArrayRes = "";
        }
        public BaseSearchIntArray(BaseIntArray array, int x) : base((uint)array.Length)
        {
            _m = 0;
            _c = 0;
            this.x = x;
            _searchRes = -1;
            _searchArrayRes = "-1";
            array.Data.CopyTo(Data, 0);
            Search(x);
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
        public int SearchRes
        {
            get
            {
                return _searchRes;
            }
            protected set { _searchRes = value; }

        }
        public string SearchArrayRes
        {
            get { return _searchArrayRes; }
            protected set { _searchArrayRes = value ; }
        }

        protected abstract void Search(int x);

        private int _m;
        private int _c;
        private int _searchRes;
        private string _searchArrayRes;
        public int x;

    }
}
