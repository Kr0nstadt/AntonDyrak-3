using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class CodeGray
    {
        public static List<String> generateGray(int n)
        {

            if (n <= 0)
            {
                List<String> temp = new List<String>();
                temp.Add("0");
                return temp;
            }
            if (n == 1)
            {
                List<String> temp = new List<String>();
                temp.Add("0");
                temp.Add("1");
                return temp;
            }

            List<String> recAns = generateGray(n - 1);
            List<String> mainAns = new List<String>();

            for (int i = 0; i < recAns.Count; i++)
            {
                String s = recAns[i];
                mainAns.Add("0" + s);
            }

            for (int i = recAns.Count - 1; i >= 0; i--)
            {
                String s = recAns[i];
                mainAns.Add("1" + s);
            }
            return mainAns;
        }
    }
}
